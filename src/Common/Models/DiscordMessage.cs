using Discord;

public class DiscordMessage(
    string? message = null,
    Embed? embed = null,
    AllowedMentions? allowedMentions = null,
    bool ephemeral = false,
    MessageReference? messageReference = null,
    MessageComponent? messageComponent = null)
{
    public string? Message { get; } = message;
    public Embed? Embed { get; } = embed;
    public AllowedMentions? AllowedMentions { get; } = allowedMentions;
    public bool Ephemeral { get; } = ephemeral;
    public MessageReference? MessageReference { get; } = messageReference;
    public MessageComponent? MessageComponent { get; } = messageComponent;
}