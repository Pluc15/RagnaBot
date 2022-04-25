using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RagnaBot.Data;
using RagnaBot.Origin;

namespace RagnaBot.Services
{
    public class MarketCollectorService
    {
        private readonly OriginClient _originClient;
        private readonly Repository _repository;
        private readonly ILogger _logger;

        public MarketCollectorService(
            OriginClient originClient,
            Repository repository,
            ILogger logger
        )
        {
            _originClient = originClient;
            _repository = repository;
            _logger = logger;
        }

        public Task Collect()
        {
            // await _originClient.GetMarketListing();
            _logger.LogInformation("TODO Collect");
            return Task.CompletedTask;
        }
    }
}