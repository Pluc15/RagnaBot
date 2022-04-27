using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using RagnaBot.Data;
using RagnaBot.Utils;

namespace RagnaBot.Services
{
    public class MvpDashboardService
    {
        private readonly Config _config;
        private readonly DiscordClient _discordClient;
        private readonly Repository _repository;
        private readonly ILogger _logger;

        public MvpDashboardService(
            Config config,
            DiscordClient discordClient,
            Repository repository,
            ILogger logger
        )
        {
            _config = config;
            _discordClient = discordClient;
            _repository = repository;
            _logger = logger;
        }

        public async Task Init()
        {
            var channel = await _discordClient.GetChannelAsync(_config.MvpTrackerChannelId);

            if (!_repository.HasDashboardMessageId(0))
                _repository.UpdateDashboardMessageId(0, (await channel.SendMessageAsync("Dashboard placeholder 1")).Id);
            if (!_repository.HasDashboardMessageId(1))
                _repository.UpdateDashboardMessageId(1, (await channel.SendMessageAsync("Dashboard placeholder 2")).Id);
            if (!_repository.HasDashboardMessageId(2))
                _repository.UpdateDashboardMessageId(2, (await channel.SendMessageAsync("Dashboard placeholder 3")).Id);
            if (!_repository.HasDashboardMessageId(3))
                _repository.UpdateDashboardMessageId(3, (await channel.SendMessageAsync("Dashboard placeholder 4")).Id);

            _logger.LogInformation("Dashboard initiated");
        }

        public async Task Update()
        {
            var channel = await _discordClient.GetChannelAsync(_config.MvpTrackerChannelId);

            await UpdateDashboardSpawned(channel, _repository.GetDashboardMessageId(0));
            await UpdateDashboardInWindow(channel, _repository.GetDashboardMessageId(1));
            await UpdateDashboardSpawningSoon(channel, _repository.GetDashboardMessageId(2));
            await UpdateDashboardSpawningInAWhile(channel, _repository.GetDashboardMessageId(3));

            _logger.LogInformation("Dashboard updated");
        }

        private async Task UpdateDashboardSpawned(
            DiscordChannel channel,
            ulong messageId
        )
        {
            var timersSpawned = _repository.GetTimersSpawned();
            var message = await channel.GetMessageAsync(messageId);
            await Messages.Dashboard("MVPs Recently Spawned", timersSpawned)
                .ModifyAsync(message);
        }

        private async Task UpdateDashboardInWindow(
            DiscordChannel channel,
            ulong messageId
        )
        {
            var timersSpawned = _repository.GetTimersInWindow();
            var message = await channel.GetMessageAsync(messageId);
            await Messages.Dashboard("MVPs In Window", timersSpawned)
                .ModifyAsync(message);
        }

        private async Task UpdateDashboardSpawningSoon(
            DiscordChannel channel,
            ulong messageId
        )
        {
            var timersSpawned = _repository.GetTimersSpawningSoon();
            var message = await channel.GetMessageAsync(messageId);
            await Messages.Dashboard("MVPs Spawning Soon", timersSpawned)
                .ModifyAsync(message);
        }

        private async Task UpdateDashboardSpawningInAWhile(
            DiscordChannel channel,
            ulong messageId
        )
        {
            var timersSpawned = _repository.GetTimersSpawningInAWhile();
            var message = await channel.GetMessageAsync(messageId);
            await Messages.Dashboard("MVPs Spawning In A While", timersSpawned)
                .ModifyAsync(message);
        }
    }
}