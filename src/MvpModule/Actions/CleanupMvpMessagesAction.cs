using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;

public class CleanupMvpMessagesAction(
    MvpConfigRepository mvpConfigRepository,
    MvpMessagesCleanupRepository MvpMessagesCleanupRepository,
    DiscordSocketClient discordClient,
    ILogger<CleanupMvpMessagesAction> logger)
{
    public async Task Run(
        string? mvpId = null
    )
    {
        foreach (var mvpMessageReference in mvpId == null ? MvpMessagesCleanupRepository.GetExpired() : MvpMessagesCleanupRepository.GetForMvpId(mvpId))
            await DeleteMessage(mvpMessageReference);
    }

    private async Task DeleteMessage(
        MvpMessageReference mvpMessageReference
    )
    {

        try
        {
            var mvpTrackerChannelId = mvpConfigRepository.GetMvpTrackerChannelId();
            if (!mvpTrackerChannelId.HasValue)
                throw new Exception("Mvp channel not configured");

            var channel = await discordClient.GetChannelAsync(mvpTrackerChannelId.Value) as IMessageChannel ?? throw new Exception("Mvp channel not found");
            var message = await channel.GetMessageAsync(mvpMessageReference.Id);
            await message.DeleteAsync();
            logger.LogInformation($"Message deleted: '{message.Content}' by '{message.Author.Username}'");
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Failed to cleanup a message");
        }

        MvpMessagesCleanupRepository.RemoveMessageToCleanup(mvpMessageReference);
    }
}