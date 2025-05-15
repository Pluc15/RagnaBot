using Discord;
using Microsoft.Extensions.Logging;

public class UpdateMarketConfigurationAction(
    MarketConfigRepository marketConfigRepository,
    ILogger<UpdateMarketConfigurationAction> logger)
{
    public void Run(
        IChannel? channel
    )
    {
        marketConfigRepository.SetMarketTrackerChannelId(channel?.Id);
        logger.LogInformation($"Market channel has been updated to '{channel?.Name}' ({channel?.Id})");
    }
}