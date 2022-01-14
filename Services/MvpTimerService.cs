using System;
using System.Linq;
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

        public async Task<Timer> RegisterTimeOfDeath(
            string mvpKey,
            DateTime timeOfDeath
        )
        {
            var timer = _repository.GetTimer(mvpKey);
            if (timer == null)
                throw new MvpTimerNotFoundException();

            timer.TimeOfDeath = timeOfDeath;
            timer.ReminderSent = false;
            await _repository.SaveAsync();

            _logger.LogInformation($"Timer updated for {timer.MvpKeys[0]} to {timer.TimeOfDeath}");

            return timer;
        }

        public async Task SendReminders()
        {
            foreach (var timer in _repository.GetTimers().Where(t => t.IsReminderDue))
            {
                var channel = await _discordClient.GetChannelAsync(_config.ChannelId);
                var message = await new DiscordMessageBuilder()
                    .WithContent(Messages.MvpSpawningSoon(timer, _config.TrackerRoleId))
                    .WithAllowedMention(new RoleMention(_config.TrackerRoleId))
                    .SendAsync(channel);
                _repository.AddMessageToCleanup(
                    message.Id,
                    timer.NextSpawn!.Value + timer.RespawnVariance + TimeSpan.FromMinutes(5)
                );

                timer.ReminderSent = true;
                await _repository.SaveAsync();

                _logger.LogInformation($"Reminder sent for {timer.MvpKeys[0]}");
            }
        }

        public async Task DeleteOldTimers()
        {
            foreach (var timer in _repository.GetTimers().Where(t => t.IsOldTimer))
            {
                timer.TimeOfDeath = null;
                timer.ReminderSent = false;
                await _repository.SaveAsync();

                _logger.LogInformation($"Old timer deleted for {timer.MvpKeys[0]}");
            }
        }
    }
}