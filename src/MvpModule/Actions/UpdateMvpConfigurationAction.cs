using Discord;
using Microsoft.Extensions.Logging;

public class UpdateMvpConfigurationAction(
    MvpConfigRepository mvpConfigRepository,
    ILogger<UpdateMvpConfigurationAction> logger)
{
    public void Run(
        IChannel? mvpTrackerChannel,
        IRole? mvpTrackerRole
    )
    {
        mvpConfigRepository.SetMvpTrackerChannelId(mvpTrackerChannel?.Id);
        mvpConfigRepository.SetMvpTrackerRoleId(mvpTrackerRole?.Id);
        logger.LogInformation($"MVP channel has been updated to '{mvpTrackerChannel?.Name}' ({mvpTrackerChannel?.Id})");
        logger.LogInformation($"MVP role has been updated to '{mvpTrackerRole?.Name}' ({mvpTrackerRole?.Id})");
    }
}