using System.Threading.Tasks;
using Discord.Interactions;

public abstract class BaseModule : InteractionModuleBase<SocketInteractionContext>
{
    protected Task RespondAsync(DiscordMessage message)
    {
        return RespondAsync(
            message.Message,
            embed: message.Embed,
            allowedMentions: message.AllowedMentions,
            ephemeral: message.Ephemeral,
            components: message.MessageComponent);
    }
}
