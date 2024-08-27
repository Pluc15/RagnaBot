using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

public static class DiscordMessages
{
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

    public static DiscordMessage MvpDashboard(
        string title,
        IEnumerable<(MvpTimer Timer, MvpInfo MvpInfo)> timersSpawned
    )
    {
        var embedBuilder = new EmbedBuilder()
            .WithTitle($"__**{title}**__");

        foreach (var timer in timersSpawned)
        {
            var nextSpawn = SpawnCalculator.GetNextSpawn(timer.Timer, timer.MvpInfo);
            var nextSpawnWindowEnd = SpawnCalculator.GetNextSpawnWindowEnd(timer.Timer, timer.MvpInfo);
            embedBuilder
                .AddField("MVP", $"{timer.MvpInfo.MvpName}\n{timer.MvpInfo.Map}", true)
                .AddField("Spawn time", $"<t:{nextSpawn.ToEpoch()}:t> to <t:{nextSpawnWindowEnd.ToEpoch()}:t>\n<t:{nextSpawn.ToEpoch()}:R>", true)
                .AddField("Reported by", Formatter.FormatUserMention(timer.Timer.ReportedByUserId), true);
        }

        return new DiscordMessage(embed: embedBuilder.Build());
    }

    public static DiscordMessage MvpTimerAdded(
        MvpTimer timer,
        MvpInfo mvpInfo
    )
    {
        var nextSpawn = SpawnCalculator.GetNextSpawn(timer, mvpInfo);
        var nextSpawnWindowEnd = SpawnCalculator.GetNextSpawnWindowEnd(timer, mvpInfo);
        var nextReminder = SpawnCalculator.GetNextReminder(timer, mvpInfo);

        var embedBuilder = new EmbedBuilder()
            .WithUrl(ArcadiaRoUrlBuilder.GetMobInfoUrl(mvpInfo.RagnarokId.ToString()))
            .WithThumbnailUrl(ArcadiaRoUrlBuilder.GetMobImageUrl(mvpInfo.RagnarokId.ToString()))
            .WithTitle(mvpInfo.MvpName)
            .AddField("Map", mvpInfo.Map, true)
            .AddField("Spawn time", $"<t:{nextSpawn.ToEpoch()}:t> to <t:{nextSpawnWindowEnd.ToEpoch()}:t>\n<t:{nextSpawn.ToEpoch()}:R>", true)
            .AddField("Reminder", $"<t:{nextReminder.ToEpoch()}:t>", true);

        return new DiscordMessage(embed: embedBuilder.Build(), ephemeral: true);
    }

    public static DiscordMessage MvpTimeTriggered(
        MvpTimer timer,
        MvpInfo mvpInfo,
        IEnumerable<ulong> mentionRoleIds
    )
    {
        var nextSpawn = SpawnCalculator.GetNextSpawn(timer, mvpInfo);
        var nextSpawnWindowEnd = SpawnCalculator.GetNextSpawnWindowEnd(timer, mvpInfo);

        var message = string.Join(
            ", ",
            mentionRoleIds
                .Select(Formatter.FormatRoleMention)
                .Union([Formatter.FormatUserMention(timer.ReportedByUserId)])
        );

        var embedBuilder = new EmbedBuilder()
            .WithUrl(ArcadiaRoUrlBuilder.GetMobInfoUrl(mvpInfo.RagnarokId.ToString()))
            .WithThumbnailUrl(ArcadiaRoUrlBuilder.GetMobImageUrl(mvpInfo.RagnarokId.ToString()))
            .WithTitle(mvpInfo.MvpName)
            .AddField("Map", mvpInfo.Map, true)
            .AddField("Spawn time", $"<t:{nextSpawn.ToEpoch()}:t> to <t:{nextSpawnWindowEnd.ToEpoch()}:t>\n<t:{nextSpawn.ToEpoch()}:R>", true);

        return new DiscordMessage(
            message,
            embed: embedBuilder.Build(),
            allowedMentions: new AllowedMentions
            {
                RoleIds = mentionRoleIds.Select(r => r).Distinct().ToList(),
                UserIds = [timer.ReportedByUserId]
            });

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

        foreach (var watcher in watchers)
            sb.AppendLine($"{watcher.ItemInfo.Name} - {watcher.Watcher.MaximumPrice}");

        var embedBuilder = new EmbedBuilder()
            .WithTitle("Watch list")
            .WithDescription(sb.ToString());

        return new DiscordMessage(embed: embedBuilder.Build(), ephemeral: true);
    }

    public static DiscordMessage MarketWatcherTriggered(
        MarketWatcher watcher,
        ShopItem shopItem,
        Shop shop,
        ItemInfo itemInfo,
        TimeSpan snoozeDuration
    )
    {
        var embedBuilder = new EmbedBuilder()
            .WithTitle(itemInfo.Name)
            .WithThumbnailUrl(ArcadiaRoUrlBuilder.GetItemImageUrl(shopItem.ItemId))
            .WithUrl(ArcadiaRoUrlBuilder.GetItemInfoUrl(shopItem.ItemId))
            .WithDescription($":bell: Market watcher triggered\n"
                + $"Watcher snoozed for ${snoozeDuration.TotalHours}h :zzz:")
            .AddField("Item Id", shopItem.ItemId.ToString(), true)
            .AddField("Item Price", shopItem.Price.ToString(), true)
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

    public static DiscordMessage MvpUnknown(
        MvpUnknownException ex)
    {
        return new DiscordMessage(ex.Message, ephemeral: true);
    }

    public static DiscordMessage MvpInvalidTimeOfDeathFormat(
        MvpInvalidTimeOfDeathFormatException ex)
    {
        return new DiscordMessage(ex.Message, ephemeral: true);
    }

    public static DiscordMessage ItemInfoNotFound(
         ItemInfoNotFoundException ex)
    {
        return new DiscordMessage($":warning: Unknown item id '{ex.ItemId}'. Did you use the correct item id?", ephemeral: true);
    }

    public static DiscordMessage UnexpectedError(
        Exception ex)
    {
        return new DiscordMessage($"Unexpected Error: {ex.Message}", ephemeral: true);
    }
}