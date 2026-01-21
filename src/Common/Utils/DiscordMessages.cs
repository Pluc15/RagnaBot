using System;
using System.Threading.Tasks;
using Discord;

public static partial class DiscordMessages
{
    public static async Task<IUserMessage> Send(IUser user, DiscordMessage discordMessage)
    {
        return await user.SendMessageAsync(
            discordMessage.Message,
            embed: discordMessage.Embed,
            allowedMentions: discordMessage.AllowedMentions);
    }

    public static async Task<IUserMessage> Send(IMessageChannel channel, DiscordMessage discordMessage)
    {
        return await channel.SendMessageAsync(
            discordMessage.Message,
            embed: discordMessage.Embed,
            allowedMentions: discordMessage.AllowedMentions,
            messageReference: discordMessage.MessageReference);
    }

    public static async Task<IUserMessage> Modify(IMessageChannel channel, ulong messageId, DiscordMessage discordMessage)
    {
        return await channel.ModifyMessageAsync(messageId, message =>
        {
            message.Content = discordMessage.Message;
            message.Embed = discordMessage.Embed;
            message.AllowedMentions = discordMessage.AllowedMentions;
        });
    }

    public static DiscordMessage UnexpectedError(
        Exception ex)
    {
        return new DiscordMessage($"Unexpected Error: {ex.Message}", ephemeral: true);
    }
}