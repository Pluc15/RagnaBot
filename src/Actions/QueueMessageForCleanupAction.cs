using System;
using Discord;

public class QueueMessageForCleanupAction(
    MvpMessagesCleanupRepository MvpMessagesCleanupRepository)
{
    public void Run(
        IMessage message,
        DateTime deletionTime,
        string? mvpId = null
    )
    {
        MvpMessagesCleanupRepository.Add(message.Id, deletionTime, mvpId);
    }
}