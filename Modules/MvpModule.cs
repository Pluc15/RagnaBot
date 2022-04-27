using System;
using System.Threading;
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
        private readonly Config _config;
        private readonly MvpTimerService _mvpTimerService;
        private readonly MvpDashboardService _mvpDashboardService;
        private readonly MessageCleanupService _messageCleanupService;
        private readonly ILogger _logger;

        public MvpModule(
            Config config,
            MvpTimerService mvpTimerService,
            MvpDashboardService mvpDashboardService,
            MessageCleanupService messageCleanupService,
            ILogger logger
        )
        {
            _config = config;
            _mvpTimerService = mvpTimerService;
            _mvpDashboardService = mvpDashboardService;
            _messageCleanupService = messageCleanupService;
            _logger = logger;
        }

        public async Task Start(
            CancellationToken ct
        )
        {
            _messageCleanupService.Register();
            await _mvpDashboardService.Init();
            await _mvpDashboardService.Update();
            while (!ct.IsCancellationRequested)
            {
                await SendReminders();
                DeleteOldTimers();
                await CleanupMessages();
                await Task.Delay(1000, ct);
            }
        }

        [Command("mvp")]
        public async Task RegisterMvpDeath(
            CommandContext ctx,
            string mvpKey,
            string timeOfDeath = null
        )
        {
            if (ctx.Channel.Id != _config.MvpTrackerChannelId)
                return;

            try
            {
                mvpKey = mvpKey.Trim().ToLower().Replace(" ", "");
                var dateTimeOfDeath = TimeOfDeathParser.Parse(timeOfDeath);
                var (timer, mvpInfo) = _mvpTimerService.RegisterTimeOfDeath(mvpKey, dateTimeOfDeath, ctx.User);
                await _messageCleanupService.CleanupForMvpId(mvpInfo.Id);
                var message = await Messages.TimerRegistered(timer, mvpInfo).SendAsync(ctx.Channel);
                _messageCleanupService.QueueForCleanup(message, DateTime.UtcNow.AddSeconds(30), mvpInfo.Id);
                await _mvpDashboardService.Update();
            }
            catch (UnknownMvpException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                var error = await ctx.Channel.SendMessageAsync(ex.Message);
                _messageCleanupService.QueueForCleanup(error, DateTime.UtcNow.AddSeconds(30));
            }
            catch (InvalidTimeOfDeathFormatException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                var error = await ctx.Channel.SendMessageAsync(ex.Message);
                _messageCleanupService.QueueForCleanup(error, DateTime.UtcNow.AddSeconds(30));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
        }

        private async Task SendReminders()
        {
            try
            {
                await _mvpTimerService.SendReminders();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled error");
            }
        }

        private void DeleteOldTimers()
        {
            try
            {
                _mvpTimerService.DeleteOldTimers();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled error");
            }
        }

        private async Task CleanupMessages()
        {
            try
            {
                await _messageCleanupService.CleanupExpired();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled error");
            }
        }
    }
}