using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using RagnaBot.Data;
using RagnaBot.Exceptions;
using RagnaBot.Models;
using RagnaBot.Utils;

namespace RagnaBot.Services
{
    public class MvpTimerService
    {
        private readonly Config _config;
        private readonly Repository _repository;
        private readonly DiscordClient _discordClient;
        private readonly ILogger _logger;

        public MvpTimerService(
            Config config,
            Repository repository,
            DiscordClient discordClient,
            ILogger logger
        )
        {
            _config = config;
            _repository = repository;
            _discordClient = discordClient;
            _logger = logger;
        }

        public (Timer Timer, MvpInfo MvpInfo) RegisterTimeOfDeath(
            string mvpKey,
            DateTime timeOfDeath,
            DiscordUser user
        )
        {
            var mvpInfo = _repository.SearchMvpInfo(mvpKey);
            if (mvpInfo == null)
                throw new UnknownMvpException();

            // TODO Check if it already exist - ask for confirmation

            var timer = _repository.CreateTimer(mvpInfo, timeOfDeath, user);

            _logger.LogInformation($"Timer updated for '{mvpInfo.Id}' to '{timer.TimeOfDeath}' by '{user.Username}'");

            return (timer, mvpInfo);
        }

        public async Task SendReminders()
        {
            foreach (var timer in _repository.GetTimersWithReminderDue())
            {
                var channel = await _discordClient.GetChannelAsync(_config.MvpTrackerChannelId);
                var mentions = new List<DiscordRole>
                {
                    channel.Guild.GetRole(_config.MvpTrackerRoleId)
                };
                if (timer.MvpInfo.IsHighEnd)
                {
                    mentions.Add(channel.Guild.GetRole(_config.HighEndMvpTeamRoleId));
                }

                var message = await Messages.MvpSpawningSoon(
                        timer.Timer,
                        timer.MvpInfo,
                        mentions
                    )
                    .SendAsync(channel);

                _repository.AddMessageToCleanup(
                    message.Id,
                    SpawnCalculator.GetNextSpawn(timer.Timer, timer.MvpInfo) + timer.MvpInfo.RespawnVariance + TimeSpan.FromMinutes(5),
                    timer.MvpInfo.Id
                );

                _repository.SetReminderSent(timer.Timer.Id);

                _logger.LogInformation($"Reminder sent for {timer.Timer.Id}");
            }
        }

        public void DeleteOldTimers()
        {
            foreach (var timer in _repository.GetTimersOldTimers())
            {
                _repository.DeleteTimer(timer.Timer.Id);
                _logger.LogInformation($"Old timer deleted for {timer.Timer.Id}");
            }
        }
    }
}