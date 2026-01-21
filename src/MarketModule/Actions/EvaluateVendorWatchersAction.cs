using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;

public class EvaluateVendorWatchersAction(
    VendorWatcherRepository vendorWatcherRepository,
    MarketListingRepository marketListingRepository,
    ItemInfoRepository itemInfoRepository,
    DiscordSocketClient discordClient,
    ILogger<EvaluateVendorWatchersAction> logger)
{
    public async Task Run()
    {
        int triggeredWatchers = 0;

        foreach (var watcher in vendorWatcherRepository.GetAllVendorWatchers())
        {
            var currentShop = marketListingRepository.GetShopByVendorName(watcher.VendorName);

            // Vendor still not vending
            if (watcher.LastKnownShop == null && currentShop == null)
                continue;

            // Vendor started vending
            if (watcher.LastKnownShop == null && currentShop != null)
            {
                var updatedWatcher = vendorWatcherRepository.UpdateLastKnownState(watcher, currentShop);

                logger.LogInformation($"Vendor started vending: {updatedWatcher}");

                var user = await discordClient.GetUserAsync(updatedWatcher.UserId) ?? throw new Exception("User not found");
                var discordMessage = DiscordMessages.VendorStartedVending(currentShop, BuildLitOfItems(currentShop));
                await DiscordMessages.Send(user, discordMessage);

                triggeredWatchers++;
                continue;
            }

            // Vendor still vending
            if (watcher.LastKnownShop != null && currentShop != null && watcher.LastKnownShop.GetShopId() == currentShop.GetShopId())
            {
                var soldItems = GetSoldItems(watcher.LastKnownShop, currentShop);
                if (soldItems.Count == 0)
                    continue;

                var updatedWatcher = vendorWatcherRepository.UpdateLastKnownState(watcher, currentShop);

                logger.LogInformation($"Vendor sold items: {updatedWatcher}");

                var user = await discordClient.GetUserAsync(updatedWatcher.UserId) ?? throw new Exception("User not found");
                var discordMessage = DiscordMessages.VendorSoldItems(currentShop, soldItems);
                await DiscordMessages.Send(user, discordMessage);

                triggeredWatchers++;
                continue;
            }

            // Vendor refreshed vending
            if (watcher.LastKnownShop != null && currentShop != null && watcher.LastKnownShop.GetShopId() != currentShop.GetShopId())
            {
                var updatedWatcher = vendorWatcherRepository.UpdateLastKnownState(watcher, currentShop);

                logger.LogInformation($"Vendor refreshed vending:\n{watcher}\n{updatedWatcher}");

                var user = await discordClient.GetUserAsync(updatedWatcher.UserId) ?? throw new Exception("User not found");
                var discordMessage = DiscordMessages.VendorRefreshedShop(watcher.LastKnownShop, BuildLitOfItems(watcher.LastKnownShop), currentShop, BuildLitOfItems(currentShop));
                await DiscordMessages.Send(user, discordMessage);

                triggeredWatchers++;
                continue;
            }

            // Vendor stopped vending
            if (watcher.LastKnownShop != null && currentShop == null)
            {
                var updatedWatcher = vendorWatcherRepository.UpdateLastKnownState(watcher, null);

                logger.LogInformation($"Vendor stopped vending:\n{watcher}");

                var user = await discordClient.GetUserAsync(updatedWatcher.UserId) ?? throw new Exception("User not found");
                var discordMessage = DiscordMessages.VendorStoppedVending(watcher.LastKnownShop, BuildLitOfItems(watcher.LastKnownShop));
                await DiscordMessages.Send(user, discordMessage);

                triggeredWatchers++;
                continue;
            }
        }

        logger.LogInformation($"Vendor watchers evaluated. {triggeredWatchers} watchers triggered.");
    }

    private List<(ItemInfo ItemInfo, int Quantity, int Price)> GetSoldItems(Shop lastKnownShop, Shop currentShop)
    {
        List<(ItemInfo ItemInfo, int Quantity, int Price)> soldItems = [];
        foreach (var lastKnownShopItem in lastKnownShop.Items)
        {
            var currentItem = currentShop.Items.FirstOrDefault(shopItem => shopItem.IsSameShopItemRowAs(lastKnownShopItem));
            if (currentItem == null)
                soldItems.Add((
                    ItemInfo: itemInfoRepository.Search(lastKnownShopItem.ItemId) ?? throw new Exception("ItemInfo not found"),
                    Quantity: lastKnownShopItem.Amount,
                    lastKnownShopItem.Price
                ));
            else if (currentItem.Amount != lastKnownShopItem.Amount)
                // TODO Not sure if we should adjust the amount on the current shop item
                soldItems.Add((
                    ItemInfo: itemInfoRepository.Search(lastKnownShopItem.ItemId) ?? throw new Exception("ItemInfo not found"),
                    Quantity: lastKnownShopItem.Amount - currentItem.Amount,
                    Price: lastKnownShopItem.Price
                ));
            else
                // It was not sold, but in case we had more than one for sale, we need to remove it from the current shop to not count it again
                currentShop = currentShop with { Items = currentShop.Items.Remove(currentItem) };
        }
        return soldItems;
    }

    private IEnumerable<(ItemInfo ItemInfo, int Quantity, int Price)> BuildLitOfItems(Shop shop)
    {
        return shop.Items.Select(shopItem => (
            ItemInfo: itemInfoRepository.Search(shopItem.ItemId) ?? throw new Exception("ItemInfo not found"),
            Quantity: shopItem.Amount,
            shopItem.Price
        ));
    }
}