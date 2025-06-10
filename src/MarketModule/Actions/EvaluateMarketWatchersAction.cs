using System;
using System.Linq;
using System.Threading.Tasks;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;

public class EvaluateMarketWatchersAction(
    MarketWatcherRepository marketWatcherRepository,
    MarketListingRepository marketListingRepository,
    ItemInfoRepository itemInfoRepository,
    DiscordSocketClient discordClient,
    ILogger<EvaluateMarketWatchersAction> logger)
{
    public async Task Run()
    {
        int triggeredWatchers = 0;

        foreach (var watcher in marketWatcherRepository.GetAllMarketWatchers())
        {
            var itemInfo = itemInfoRepository.Search(watcher.ItemId) ?? throw new ItemInfoNotFoundException(watcher.ItemId);

            var shops = marketListingRepository.Search(
                watcher.ItemId,
                watcher.MaximumPrice,
                watcher.MinimumQuantity
            );

            if (!shops.Any())
                continue;

            triggeredWatchers++;

            var user = await discordClient.GetUserAsync(watcher.UserId) ?? throw new Exception("User not found");

            logger.LogInformation($"Market watcher triggered: {watcher}");

            foreach (var shop in shops)
            {
                var discordMessage = DiscordMessages.MarketWatcherTriggered(watcher, shop.ShopItem, shop.Shop, itemInfo);

                await DiscordMessages.Send(user, discordMessage);
            }

            marketWatcherRepository.UpdateShopsNotified(
                watcher.UserId,
                watcher.ItemId,
                shops.Select(shop => shop.Shop.GetShopId()).ToList()
            );
        }

        logger.LogInformation($"Market watchers evaluated. {triggeredWatchers} watchers triggered.");
    }
}