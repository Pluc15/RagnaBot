using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using RagnaBot.Data;
using RagnaBot.Exceptions;
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

        public async Task<(Timer Timer, MvpInfo MvpInfo)> RegisterTimeOfDeath(
            string mvpKey,
            DateTime timeOfDeath,
            DiscordUser user
        )
        {
            var mvpInfo = _repository.SearchMvpInfo(mvpKey);
            if (mvpInfo == null)
                throw new UnknownMvpException();

            // TODO Check if it already exist - ask for confirmation

            var timer = await _repository.CreateTimer(mvpInfo, timeOfDeath, user);

            _logger.LogInformation($"Timer updated for '{mvpInfo.Id}' to '{timer.TimeOfDeath}' by '{user.Username}'");

            return (timer, mvpInfo);
        }

        public async Task SendReminders()
        {
            foreach (var timer in _repository.GetTimersWithReminderDue())
            {
                var mvpInfo = _repository.GetMvpInfoById(timer.Id);
                var channel = await _discordClient.GetChannelAsync(_config.ChannelId);
                var mentionRoles = new List<DiscordRole>
                {
                    channel.Guild.GetRole(_config.TrackerRoleId)
                };
                if (mvpInfo.IsHighEnd)
                {
                    mentionRoles.Add(channel.Guild.GetRole(_config.HighEndMvpTeamRoleId));
                }

                var message = await Messages.MvpSpawningSoon(
                        _config,
                        timer,
                        mvpInfo,
                        mentionRoles
                    )
                    .SendAsync(channel);

                await _repository.AddMessageToCleanup(
                    message.Id,
                    SpawnCalculator.GetNextSpawn(timer, mvpInfo) + mvpInfo.RespawnVariance + TimeSpan.FromMinutes(5)
                );

                await _repository.SetReminderSent(timer.Id);

                _logger.LogInformation($"Reminder sent for {timer.Id}");
            }
        }

        public async Task DeleteOldTimers()
        {
            foreach (var timer in _repository.GetTimersOldTimers())
            {
                await _repository.DeleteTimer(timer.Id);
                _logger.LogInformation($"Old timer deleted for {timer.Id}");
            }
        }
    }
}