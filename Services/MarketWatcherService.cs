using System;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using RagnaBot.Data;
using RagnaBot.Exceptions;
using RagnaBot.Utils;

namespace RagnaBot.Services
{
    public class MarketWatcherService
    {
        private readonly Config _config;
        private readonly Repository _repository;
        private readonly DiscordClient _discordClient;
        private readonly ILogger _logger;

        public MarketWatcherService(
            Config config,
            Repository repository,
            DiscordClient discordClient,
            ILogger logger 
        )
        {
            _config = config;
            _repository = repository;
            _discordClient = discordClient;
            _logger = logger;
        }

        public void AddWatcher(
            DiscordUser user,
            int itemId,
            int maximumPrice
        )
        {
            _repository.AddOrReplaceMarketWatcher(user.Id, itemId, maximumPrice);
        }

        public void DeleteWatcher(
            DiscordUser user,
            int itemId
        )
        {
            if (_repository.DeleteMarketWatcher(user.Id, itemId) == 0)
            {
                throw new MarketWatcherNotFound();
            }
        }


        public async Task HandleMarketWatchers()
        {
            var triggeredMarketWatchers = _repository.GetAllMarketWatchers()
                .Where(watcher => watcher.SnoozedUntil == null || DateTime.UtcNow > watcher.SnoozedUntil)
                .Select(
                    watcher =>
                    {
                        var (shop1, item1) = _repository.GetMarketLowestPrice(watcher.ItemId);
                        return (Watcher: watcher, Item: item1, Shop: shop1);
                    }
                )
                .Where(o => o.Item != null)
                .Where(o => o.Watcher.MaximumPrice >= o.Item.Price)
                .ToList();
            
            _logger.LogInformation($"'{triggeredMarketWatchers.Count}' watchers triggered");

            var channel = await _discordClient.GetChannelAsync(_config.MarketTrackerChannelId);

            foreach (var (watcher, item, shop) in triggeredMarketWatchers)
            {
                await Messages.MarketWatcherTriggered(watcher, item, shop)
                    .SendAsync(channel);
                _repository.SnoozeWatcher(watcher.UserId, watcher.ItemId, TimeSpan.FromHours(1));
            }
        }
    }
}