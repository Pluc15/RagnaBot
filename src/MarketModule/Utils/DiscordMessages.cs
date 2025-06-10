using System;
using System.Collections.Generic;
using System.Text;
using Discord;

// TODO Split the partial
public static partial class DiscordMessages
{
    public static DiscordMessage MarketConfigurationUpdated()
    {
        return new DiscordMessage(message: "Market configuration updated :check:", ephemeral: true);
    }

    public static DiscordMessage MarketWatcherCreated(
        ItemInfo itemInfo,
        MarketWatcher watcher
    )
    {
        var embedBuilder = new EmbedBuilder()
                    .WithTitle(itemInfo.Name)
                    .WithThumbnailUrl(ArcadiaRoUrlBuilder.GetItemImageUrl(itemInfo.Id))
                    .WithUrl(ArcadiaRoUrlBuilder.GetItemInfoUrl(itemInfo.Id))
                    .WithDescription(":white_check_mark: Market watcher created")
                    .AddField("Item Id", itemInfo.Id.ToString(), true)
                    .AddField("Maximum Price", watcher.MaximumPrice.ToString(), true);

        return new DiscordMessage(embed: embedBuilder.Build(), ephemeral: true);
    }

    public static DiscordMessage MarketWatcherDeleted(
        ItemInfo itemInfo
    )
    {
        var embedBuilder = new EmbedBuilder()
                    .WithTitle(itemInfo.Name)
                    .WithThumbnailUrl(ArcadiaRoUrlBuilder.GetItemImageUrl(itemInfo.Id))
                    .WithUrl(ArcadiaRoUrlBuilder.GetItemInfoUrl(itemInfo.Id))
                    .WithDescription(":x: Market watcher deleted")
                    .AddField("Item Id", itemInfo.Id.ToString(), true);

        return new DiscordMessage(embed: embedBuilder.Build(), ephemeral: true);
    }

    public static DiscordMessage MarketWatcherList(
        IEnumerable<(MarketWatcher Watcher, ItemInfo ItemInfo)> watchers
    )
    {
        var sb = new StringBuilder();
        sb.AppendLine("# Watch list");
        sb.AppendLine("```");
        sb.AppendLine("Item Name            | Item Id | Max Price    | Min Amount");
        sb.AppendLine("-------------------- | ------- | ------------ | ----------");

        foreach (var watcher in watchers)
            sb.AppendLine(
                $"{watcher.ItemInfo.Name,-20} | " +
                $"{watcher.ItemInfo.Id,-7} | " +
                $"{watcher.Watcher.MaximumPrice,-12} | " +
                $"{watcher.Watcher.MinimumQuantity,-10}"
            );
        sb.AppendLine("```");

        return new DiscordMessage(message: sb.ToString(), ephemeral: true);
    }

    public static DiscordMessage MarketWatcherTriggered(
        MarketWatcher watcher,
        ShopItem shopItem,
        Shop shop,
        ItemInfo itemInfo
    )
    {
        var embedBuilder = new EmbedBuilder()
            .WithTitle(itemInfo.Name)
            .WithThumbnailUrl(ArcadiaRoUrlBuilder.GetItemImageUrl(shopItem.ItemId))
            .WithUrl(ArcadiaRoUrlBuilder.GetItemInfoUrl(shopItem.ItemId))
            .WithDescription($":bell: Market watcher triggered")
            .AddField("Item Id", shopItem.ItemId.ToString(), true)
            .AddField("Item Price", shopItem.Price.ToString(), true)
            .AddField("Amount", shopItem.Amount.ToString(), true)
            .AddField("Shop", $"`@navshop {shop.Owner}`", true);

        return new DiscordMessage(
            Formatter.FormatUserMention(watcher.UserId),
            embed: embedBuilder.Build(),
            allowedMentions: new AllowedMentions
            {
                UserIds = [watcher.UserId]
            });
    }

    public static DiscordMessage MarketWatcherNotFound(
        MarketWatcherNotFoundException ex
    )
    {
        return new DiscordMessage($":warning: No market watchers found for item id '{ex.ItemId}'.", ephemeral: true);
    }

    public static DiscordMessage ItemInfoNotFound(
         ItemInfoNotFoundException ex)
    {
        return new DiscordMessage($":warning: Unknown item id '{ex.ItemId}'. Did you use the correct item id?", ephemeral: true);
    }
}