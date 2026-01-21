using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class MarketDataJob(
        UpdateMarketAction updateMarketAction,
        EvaluateMarketWatchersAction evaluateMarketWatchersAction,
        EvaluateVendorWatchersAction evaluateVendorWatchersAction,
        ILogger<MarketDataJob> logger
    )
{
    public async Task Start(
        CancellationToken ct
    )
    {
        logger.LogInformation("Starting the MarketDataJob");
        while (!ct.IsCancellationRequested)
        {
            try
            {
                await updateMarketAction.Run();
                await evaluateMarketWatchersAction.Run();
                await evaluateVendorWatchersAction.Run();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
            await Task.Delay(TimeSpan.FromMinutes(11), ct);
        }
    }
}
