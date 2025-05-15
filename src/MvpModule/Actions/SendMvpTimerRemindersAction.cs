using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;

public class SendMvpTimerRemindersAction(
    MvpConfigRepository mvpConfigRepository,
    MvpTimersRepository mvpTimersRepository,
    MvpMessagesCleanupRepository mvpMessagesCleanupRepository,
    DiscordSocketClient discordClient,
    ILogger<SendMvpTimerRemindersAction> logger)
{
    public async Task Run()
    {
        var mvpTrackerChannelId = mvpConfigRepository.GetMvpTrackerChannelId();
        if (!mvpTrackerChannelId.HasValue)
            return;

        var channel = await discordClient.GetChannelAsync(mvpTrackerChannelId.Value) as IMessageChannel ?? throw new Exception("Mvp channel not found");

        var roles = new List<ulong>();

        var mvpTrackerRoleId = mvpConfigRepository.GetMvpTrackerRoleId();
        if (mvpTrackerRoleId.HasValue)
            roles.Add(mvpTrackerRoleId.Value);

        foreach (var timer in mvpTimersRepository.GetTimersWithReminderDue())
        {
            var discordMessage = DiscordMessages.MvpTimeTriggered(timer.Timer, timer.MvpInfo, roles);
            var message = await DiscordMessages.Send(channel, discordMessage);

            mvpMessagesCleanupRepository.Add(
                message.Id,
                SpawnCalculator.GetNextSpawn(timer.Timer, timer.MvpInfo) + timer.MvpInfo.RespawnVariance + TimeSpan.FromMinutes(5),
                timer.MvpInfo.Id
            );

            mvpTimersRepository.SetReminderSent(timer.Timer.Id);

            logger.LogInformation($"Reminder sent for {timer.Timer.Id}");
        }
    }
}