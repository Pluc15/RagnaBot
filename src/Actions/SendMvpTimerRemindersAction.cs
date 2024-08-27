using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public class SendMvpTimerRemindersAction(
    IOptions<Config> config,
    MvpTimersRepository mvpTimersRepository,
    MvpMessagesCleanupRepository mvpMessagesCleanupRepository,
    DiscordSocketClient discordClient,
    ILogger<SendMvpTimerRemindersAction> logger)
{
    public async Task Run()
    {
        foreach (var timer in mvpTimersRepository.GetTimersWithReminderDue())
        {
            var channel = await discordClient.GetChannelAsync(config.Value.MvpTrackerChannelId) as IMessageChannel ?? throw new Exception("Mvp channel not found");

            var roles = new List<ulong>
            {
                config.Value.MvpTrackerRoleId
            };

            if (timer.MvpInfo.IsHighEnd)
            {
                roles.Add(config.Value.MvpHighEndTeamRoleId);
            }

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