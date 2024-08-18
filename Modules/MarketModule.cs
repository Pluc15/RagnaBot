using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Microsoft.Extensions.Logging;
using RagnaBot.Data;
using RagnaBot.Exceptions;
using RagnaBot.Services;
using RagnaBot.Utils;

namespace RagnaBot.Modules
{
    public class MarketModule : BaseCommandModule
    {
        private readonly Config _config;
        private readonly MarketCollectorService _marketCollectorService;
        private readonly MarketWatcherService _marketWatcherService;
        private readonly Repository _repository;
        private readonly ILogger _logger;

        public MarketModule(
            Config config,
            MarketCollectorService marketCollectorService,
            MarketWatcherService marketWatcherService,
            Repository repository,
            ILogger logger
        )
        {
            _config = config;
            _marketCollectorService = marketCollectorService;
            _marketWatcherService = marketWatcherService;
            _repository = repository;
            _logger = logger;
        }

        public async Task Start(
            CancellationToken ct
        )
        {
            await _repository.LoadMarketListing();
            while (!ct.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromMinutes(11), ct);
                try
                {
                    await _marketCollectorService.Collect();
                    await _repository.SaveMarketListing();
                    await _marketWatcherService.HandleMarketWatchers();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }
        }

        [Command("watch")]
        public async Task Watch(
            CommandContext ctx,
            int itemId,
            int maximumPrice
        )
        {
            if (ctx.Channel.Id != _config.MarketTrackerChannelId)
                return;

            try
            {
                _marketWatcherService.AddWatcher(ctx.User, itemId, maximumPrice);
                await ctx.RespondAsync(Messages.MarketWatcherCreated(itemId, maximumPrice));
                _logger.LogInformation($"Watcher created for user '{ctx.User.Username}' for item id '{itemId}' when price is equal or under '{maximumPrice}'");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        [Command("unwatch")]
        public async Task Unwatch(
            CommandContext ctx,
            int itemId
        )
        {
            if (ctx.Channel.Id != _config.MarketTrackerChannelId)
                return;

            try
            {
                _marketWatcherService.DeleteWatcher(ctx.User, itemId);
                await ctx.RespondAsync(Messages.MarketWatcherDeleted(itemId));
                _logger.LogInformation($"Watcher deleted for user '{ctx.User.Username}' for item id '{itemId}'");
            }
            catch (MarketWatcherNotFound)
            {
                await ctx.RespondAsync(Messages.MarketWatcherNotFound(itemId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        [Command("watchlist")]
        public async Task Watchlist(
            CommandContext ctx
        )
        {
            if (ctx.Channel.Id != _config.MarketTrackerChannelId)
                return;

            try
            {
                var watchers = _marketWatcherService.GetWatcherForUser(ctx.User);
                await ctx.RespondAsync(Messages.MarketWatcherList(watchers));
                _logger.LogInformation($"Watcher list requested by user '{ctx.User.Username}'");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}