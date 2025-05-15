using System;
using Discord;
using Microsoft.Extensions.Logging;

public class QueueMvpMessageForCleanupAction(
    MvpMessagesCleanupRepository MvpMessagesCleanupRepository,
    ILogger<QueueMvpMessageForCleanupAction> logger)
{
    public void Run(
        IMessage message,
        DateTime deletionTime,
        string? mvpId = null
    )
    {
        MvpMessagesCleanupRepository.Add(message.Id, deletionTime, mvpId);

        logger.LogInformation($"Added following message to cleanup at {deletionTime} or the death of mvp Id '{mvpId}': '{message.Content}'");
    }
}