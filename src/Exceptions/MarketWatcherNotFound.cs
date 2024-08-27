using System;
using Discord;

public class MarketWatcherNotFoundException(IUser discordUser, int itemId) : Exception($"Market watcher not found for item id {itemId} and discord user {discordUser.Username}.")
{
    public IUser DiscordUser { get; } = discordUser;

    public int ItemId { get; } = itemId;
}