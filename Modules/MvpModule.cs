using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Microsoft.Extensions.Logging;
using RagnaBot.Exceptions;
using RagnaBot.Services;
using RagnaBot.Utils;

namespace RagnaBot.Modules
{
    public class MvpModule : BaseCommandModule
    {
        private readonly MvpTimerService _mvpTimerService;
        private readonly MvpDashboardService _mvpDashboardService;
        private readonly MessageCleanupService _messageCleanupService;
        private readonly ILogger _logger;

        public MvpModule(
            MvpTimerService mvpTimerService,
            MvpDashboardService mvpDashboardService,
            MessageCleanupService messageCleanupService,
            ILogger logger
        )
        {
            _mvpTimerService = mvpTimerService;
            _mvpDashboardService = mvpDashboardService;
            _messageCleanupService = messageCleanupService;
            _logger = logger;
        }

        [Command("mvp")]
        public async Task RegisterMvpDeath(
            CommandContext ctx,
            string mvpKey,
            string timeOfDeath = null
        )
        {
            try
            {
                mvpKey = mvpKey.Trim().ToLower().Replace(" ", "");
                var dateTimeOfDeath = ParseTimeOfDeath(timeOfDeath);
                var timer = await _mvpTimerService.RegisterTimeOfDeath(mvpKey, dateTimeOfDeath);
                var message = await ctx.Channel.SendMessageAsync(Messages.TimerRegistered(timer));
                await _messageCleanupService.QueueForCleanup(message, DateTime.UtcNow.AddSeconds(30));
                await _mvpDashboardService.Update();
            }
            catch (MvpTimerNotFoundException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                var error = await ctx.Channel.SendMessageAsync(ex.Message);
                await _messageCleanupService.QueueForCleanup(error, DateTime.UtcNow.AddSeconds(30));
            }
            catch (InvalidCommandArgumentsException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                var error = await ctx.Channel.SendMessageAsync(ex.Message);
                await _messageCleanupService.QueueForCleanup(error, DateTime.UtcNow.AddSeconds(30));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        private static DateTime ParseTimeOfDeath(
            string timeOfDeath
        )
        {
            if (string.IsNullOrEmpty(timeOfDeath))
                return DateTime.UtcNow;

            var tombFormat = Regex.Match(timeOfDeath, "^([0-9]|[0-1][0-9]|2[0-3])[:h]?([0-5][0-9])$");
            if (tombFormat.Success)
            {
                var hours = Convert.ToInt32(tombFormat.Groups[1].Value);
                var minutes = Convert.ToInt32(tombFormat.Groups[2].Value);

                var timeSpanOfDeath = TimeSpan.FromMinutes(hours * 60 + minutes);

                return DateTime.UtcNow.TimeOfDay >= timeSpanOfDeath
                    ? DateTime.UtcNow.Date.Add(timeSpanOfDeath)
                    : DateTime.UtcNow.Date.AddDays(-1).Add(timeSpanOfDeath);
            }

            var agoFormat = Regex.Match(timeOfDeath, "^([1-9][0-9]*)m$");
            if (agoFormat.Success)
            {
                var minutesAgo = Convert.ToInt32(agoFormat.Groups[1].Value);

                return DateTime.UtcNow.AddMinutes(-minutesAgo);
            }

            throw new InvalidCommandArgumentsException(Messages.InvalidTimeOfDeathFormat());
        }
    }
}