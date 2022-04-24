using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using RagnaBot.Data;

namespace RagnaBot.Services
{
    public class MessageCleanupService
    {
        private readonly Config _config;
        private readonly DiscordClient _discordClient;
        private readonly Repository _repository;
        private readonly ILogger _logger;

        public MessageCleanupService(
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

        public Task QueueForCleanup(
            DiscordMessage message,
            DateTime deletionTime
        )
        {
            return _repository.AddMessageToCleanup(message.Id, deletionTime);
        }

        public async Task Cleanup()
        {
            foreach (var messageRef in _repository.GetMessageToCleanups())
            {
                try
                {
                    var channel = await _discordClient.GetChannelAsync(_config.ChannelId);
                    var message = await channel.GetMessageAsync(messageRef.Id);
                    await message.DeleteAsync();
                    _logger.LogInformation($"Message deleted: '{message.Content}' by '{message.Author.Username}'");
                }
                catch (DSharpPlus.Exceptions.NotFoundException ex)
                {
                    _logger.LogWarning(ex, "Failed to cleanup a message");
                }

                await _repository.RemoveMessageToCleanup(messageRef);
            }
        }

        public void RegisterAutoCleanup()
        {
            _discordClient.MessageCreated += async (
                _,
                args
            ) =>
            {
                if (args.Channel.Id == _config.ChannelId && _discordClient.CurrentUser.Id != args.Author.Id)
                    await QueueForCleanup(args.Message, DateTime.UtcNow.AddSeconds(5));
            };

            _logger.LogInformation("AutoCleanup registered");
        }
    }
}