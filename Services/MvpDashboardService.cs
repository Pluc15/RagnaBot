using System.Linq;
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
                _repository.UpdateDashboardMessageId(0, (await channel.SendMessageAsync("Dashboard placeholder 1")).Id);
            if (!_repository.HasDashboardMessageId(1))
                _repository.UpdateDashboardMessageId(1, (await channel.SendMessageAsync("Dashboard placeholder 2")).Id);
            if (!_repository.HasDashboardMessageId(2))
                _repository.UpdateDashboardMessageId(2, (await channel.SendMessageAsync("Dashboard placeholder 3")).Id);
            if (!_repository.HasDashboardMessageId(3))
                _repository.UpdateDashboardMessageId(3, (await channel.SendMessageAsync("Dashboard placeholder 4")).Id);
            await _repository.SaveAsync();

            _logger.LogInformation("Dashboard initiated");
        }

        public async Task Update()
        {
            var channel = await _discordClient.GetChannelAsync(_config.ChannelId);

            await UpdatePage(channel, _repository.GetDashboardMessageId(0), 1);
            await UpdatePage(channel, _repository.GetDashboardMessageId(1), 2);
            await UpdatePage(channel, _repository.GetDashboardMessageId(2), 3);
            await UpdatePage(channel, _repository.GetDashboardMessageId(3), 4);

            _logger.LogInformation("Dashboard updated");
        }

        private async Task UpdatePage(
            DiscordChannel channel,
            ulong messageId,
            int page
        )
        {
            var message = await channel.GetMessageAsync(messageId);
            await new DiscordMessageBuilder()
                .WithContent(BuildDashboardContent(page))
                .ModifyAsync(message);
        }

        private string BuildDashboardContent(
            int page
        )
        {
            var newDashboardContent = new StringBuilder();
            newDashboardContent.AppendLine($"__**Dashboard Page {page}**__");
            foreach (var timer in _repository.GetTimers()
                         .Where(t => t.Page == page)
                         .Where(t => t.NextSpawn.HasValue)
                         .OrderBy(t => t.NextSpawn))
            {
                var spawnTime = timer.NextSpawn.HasValue
                    ? $"<t:{timer.NextSpawn.Value.ToEpoch()}:R>"
                    : "`unknown`";

                newDashboardContent.AppendLine($"`{timer.MvpName}` on map `{timer.Map}` will spawn {spawnTime}");
            }

            return newDashboardContent.ToString();
        }
    }
}