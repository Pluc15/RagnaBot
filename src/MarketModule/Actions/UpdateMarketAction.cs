using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class UpdateMarketAction(
    ArcadiaClient arcadiaClient,
    MarketListingRepository marketListingRepository,
    ILogger<UpdateMarketAction> logger)
{
    public async Task Run()
    {
        var marketListing = await arcadiaClient.GetMarketListing();
        await marketListingRepository.UpdateAsync(marketListing);

        logger.LogInformation("Market data updated.");
    }
}