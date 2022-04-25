using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using RagnaBot.Data;
using RagnaBot.Models;

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

        public void Register()
        {
            _discordClient.MessageCreated += (
                _,
                args
            ) =>
            {
                if (args.Channel.Id == _config.ChannelId && _discordClient.CurrentUser.Id != args.Author.Id)
                    QueueForCleanup(args.Message, DateTime.UtcNow.AddSeconds(5));
                return Task.CompletedTask;
            };

            _logger.LogInformation("AutoCleanup registered");
        }

        public void QueueForCleanup(
            DiscordMessage message,
            DateTime deletionTime,
            string mvpId = null
        )
        {
            _repository.AddMessageToCleanup(message.Id, deletionTime, mvpId);
        }

        public async Task CleanupForMvpId(
            string mvpId
        )
        {
            foreach (var messageRef in _repository.GetMessagesToCleanupForMvpId(mvpId))
                await DeleteMessage(messageRef);
        }

        public async Task CleanupExpired()
        {
            foreach (var messageRef in _repository.GetMessagesToCleanupExpired())
                await DeleteMessage(messageRef);
        }

        private async Task DeleteMessage(
            MessageReference messageRef
        )
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

            _repository.RemoveMessageToCleanup(messageRef);
        }
    }
}