using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;

public class EvaluateMarketWatchersAction(
    MarketConfigRepository marketChannelRepository,
    MarketWatcherRepository marketWatcherRepository,
    MarketListingRepository marketListingRepository,
    ItemInfoRepository itemInfoRepository,
    DiscordSocketClient discordClient,
    ILogger<EvaluateMarketWatchersAction> logger)
{
    public async Task Run()
    {
        var triggeredMarketWatchers = marketWatcherRepository
            .GetAllMarketWatchers()
            .Where(watcher => watcher.SnoozedUntil == null || DateTime.UtcNow > watcher.SnoozedUntil)
            .Select(
                watcher =>
                {
                    var (shop, shopItem) = marketListingRepository.GetMarketLowestPrice(watcher.ItemId);
                    return (Watcher: watcher, ShopItem: shopItem, Shop: shop);
                }
            )
            .Where(o => o.ShopItem != null)
            .Where(o => o.Watcher.MaximumPrice >= o.ShopItem.Price)
            .Select(
                watcher =>
                {
                    var itemInfo = itemInfoRepository.Search(watcher.ShopItem.ItemId) ?? throw new ItemInfoNotFoundException(watcher.ShopItem.ItemId);
                    return (watcher.Watcher, watcher.ShopItem, watcher.Shop, ItemInfo: itemInfo);
                }
            )
            .ToList();

        logger.LogInformation($"'{triggeredMarketWatchers.Count}' watchers conditions met.");

        if (triggeredMarketWatchers.Count == 0)
            return;

        var channel = await discordClient.GetChannelAsync(marketChannelRepository.GetMarketTrackerChannelId()) as IMessageChannel ?? throw new Exception("Market channel not found");

        foreach (var (watcher, shopItem, shop, itemInfo) in triggeredMarketWatchers)
        {
            var snoozeDuration = TimeSpan.FromHours(12);
            var discordMessage = DiscordMessages.MarketWatcherTriggered(watcher, shopItem, shop, itemInfo, snoozeDuration);
            await DiscordMessages.Send(channel, discordMessage);
            marketWatcherRepository.Snooze(watcher.UserId, watcher.ItemId, snoozeDuration);
        }

        logger.LogInformation($"'{triggeredMarketWatchers.Count}' watchers notifications sent.");
    }
}