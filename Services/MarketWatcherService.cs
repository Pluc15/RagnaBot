using System.Threading.Tasks;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using RagnaBot.Data;

namespace RagnaBot.Services
{
    public class MarketWatcherService
    {
        private readonly Repository _repository;
        private readonly ILogger _logger;

        public MarketWatcherService(
            Repository repository,
            ILogger logger
        )
        {
            _repository = repository;
            _logger = logger;
        }

        public Task AddWatcher(
            string itemId,
            string maximumPrice,
            DiscordUser user
        )
        {
            _logger.LogInformation("TODO AddWatcher");
            return Task.CompletedTask;
        }

        public Task GetTriggeredMarketWatcher()
        {
            _logger.LogInformation("TODO GetTriggeredMarketWatcher");
            return Task.CompletedTask;
        }
    }
}