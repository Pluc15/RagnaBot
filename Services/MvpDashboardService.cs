using System.Text;
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
            var channel = await _discordClient.GetChannelAsync(_config.ChannelId);

            if (!_repository.HasDashboardMessageId(0))
                await _repository.UpdateDashboardMessageId(0, (await channel.SendMessageAsync("Dashboard placeholder 1")).Id);
            if (!_repository.HasDashboardMessageId(1))
                await _repository.UpdateDashboardMessageId(1, (await channel.SendMessageAsync("Dashboard placeholder 2")).Id);
            if (!_repository.HasDashboardMessageId(2))
                await _repository.UpdateDashboardMessageId(2, (await channel.SendMessageAsync("Dashboard placeholder 3")).Id);
            if (!_repository.HasDashboardMessageId(3))
                await _repository.UpdateDashboardMessageId(3, (await channel.SendMessageAsync("Dashboard placeholder 4")).Id);

            _logger.LogInformation("Dashboard initiated");
        }

        public async Task Update()
        {
            var channel = await _discordClient.GetChannelAsync(_config.ChannelId);

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
            var newDashboardContent = new StringBuilder();
            newDashboardContent.AppendLine("__**MVPs Recently Spawned**__");
            foreach (var timer in _repository.GetTimersSpawned())
            {
                var mvpInfo = _repository.GetMvpInfoById(timer.Id);
                var nextSpawnWindowEnd = SpawnCalculator.GetNextSpawnWindowEnd(timer, mvpInfo);
                newDashboardContent.AppendLine($"`{mvpInfo.MvpName}` on map `{mvpInfo.Map}` spawn windows ended <t:{nextSpawnWindowEnd.ToEpoch()}:R>");
            }

            var message = await channel.GetMessageAsync(messageId);
            await new DiscordMessageBuilder()
                .WithContent(newDashboardContent.ToString())
                .ModifyAsync(message);
        }

        private async Task UpdateDashboardInWindow(
            DiscordChannel channel,
            ulong messageId
        )
        {
            var newDashboardContent = new StringBuilder();
            newDashboardContent.AppendLine("__**MVPs In Window**__");
            foreach (var timer in _repository.GetTimersInWindow())
            {
                var mvpInfo = _repository.GetMvpInfoById(timer.Id);
                var nextSpawnWindowEnd = SpawnCalculator.GetNextSpawnWindowEnd(timer, mvpInfo);
                newDashboardContent.AppendLine($"`{mvpInfo.MvpName}` on map `{mvpInfo.Map}` is in window ending <t:{nextSpawnWindowEnd.ToEpoch()}:R>");
            }

            var message = await channel.GetMessageAsync(messageId);
            await new DiscordMessageBuilder()
                .WithContent(newDashboardContent.ToString())
                .ModifyAsync(message);
        }

        private async Task UpdateDashboardSpawningSoon(
            DiscordChannel channel,
            ulong messageId
        )
        {
            var newDashboardContent = new StringBuilder();
            newDashboardContent.AppendLine("__**MVPs Spawning Soon**__");
            foreach (var timer in _repository.GetTimersSpawningSoon())
            {
                var mvpInfo = _repository.GetMvpInfoById(timer.Id);
                var nextSpawn = SpawnCalculator.GetNextSpawn(timer, mvpInfo);
                newDashboardContent.AppendLine($"`{mvpInfo.MvpName}` on map `{mvpInfo.Map}` will be in spawn window <t:{nextSpawn.ToEpoch()}:R>");
            }

            var message = await channel.GetMessageAsync(messageId);
            await new DiscordMessageBuilder()
                .WithContent(newDashboardContent.ToString())
                .ModifyAsync(message);
        }

        private async Task UpdateDashboardSpawningInAWhile(
            DiscordChannel channel,
            ulong messageId
        )
        {
            var newDashboardContent = new StringBuilder();
            newDashboardContent.AppendLine("__**MVPs Spawning In A While**__");
            foreach (var timer in _repository.GetTimersSpawningInAWhile())
            {
                var mvpInfo = _repository.GetMvpInfoById(timer.Id);
                var nextSpawn = SpawnCalculator.GetNextSpawn(timer, mvpInfo);
                newDashboardContent.AppendLine($"`{mvpInfo.MvpName}` on map `{mvpInfo.Map}` will be in spawn window <t:{nextSpawn.ToEpoch()}:R>");
            }

            var message = await channel.GetMessageAsync(messageId);
            await new DiscordMessageBuilder()
                .WithContent(newDashboardContent.ToString())
                .ModifyAsync(message);
        }
    }
}