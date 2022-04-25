using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Microsoft.Extensions.Logging;
using RagnaBot.Exceptions;
using RagnaBot.Services;
using RagnaBot.Utils;

namespace RagnaBot.Modules
{
    public class MarketModule : BaseCommandModule
    {
        private readonly MarketCollectorService _marketCollectorService;
        private readonly MarketWatcherService _marketWatcherService;
        private readonly ILogger _logger;

        public MarketModule(
            MarketCollectorService marketCollectorService,
            MarketWatcherService marketWatcherService,
            ILogger logger
        )
        {
            _marketCollectorService = marketCollectorService;
            _marketWatcherService = marketWatcherService;
            _logger = logger;
        }

        public async Task Start(
            CancellationToken ct
        )
        {
            while (!ct.IsCancellationRequested)
            {
                try
                {
                    await _marketCollectorService.Collect();
                    await _marketWatcherService.GetTriggeredMarketWatcher();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
                finally
                {
                    await Task.Delay(TimeSpan.FromMinutes(11), ct);
                }
            }
        }

        [Command("watch")]
        public async Task AddWatcher(
            CommandContext ctx,
            string itemId,
            string maximumPrice
        )
        {
            try
            {
                await _marketWatcherService.AddWatcher(itemId, maximumPrice, ctx.User);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}