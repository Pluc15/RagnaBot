using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public class CleanupMvpMessagesAction(
    IOptions<Config> config,
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
            var channel = await discordClient.GetChannelAsync(config.Value.MvpTrackerChannelId) as IMessageChannel ?? throw new Exception("Mvp channel not found");
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