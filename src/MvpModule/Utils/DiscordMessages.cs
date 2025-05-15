using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;

// TODO Split the partial
public static partial class DiscordMessages
{
    public static DiscordMessage MvpConfigurationUpdated()
    {
        return new DiscordMessage(message: "MVP configuration updated :check:", ephemeral: true);
    }

    public static DiscordMessage MvpDashboard(
        string title,
        IEnumerable<(MvpTimer Timer, MvpInfo MvpInfo)> timersSpawned
    )
    {
        var message = new StringBuilder();
        message.AppendLine($"# {title}");
        foreach (var timer in timersSpawned)
        {
            var nextSpawn = SpawnCalculator.GetNextSpawn(timer.Timer, timer.MvpInfo);
            var nextSpawnWindowEnd = SpawnCalculator.GetNextSpawnWindowEnd(timer.Timer, timer.MvpInfo);
            message.AppendLine(
                $"{timer.MvpInfo.MvpName} - {timer.MvpInfo.Map}" +
                $" | <t:{nextSpawn.ToEpoch()}:t> to <t:{nextSpawnWindowEnd.ToEpoch()}:t> - <t:{nextSpawn.ToEpoch()}:R>" +
                $" | {Formatter.FormatUserMention(timer.Timer.ReportedByUserId)}");
        }

        return new DiscordMessage(message.ToString());
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

    public static DiscordMessage MvpTimerAlreadyExists(
        MvpTimer mvpTimer,
        MvpInfo mvpInfo,
        string overrideCustomId
    )
    {
        var nextSpawn = SpawnCalculator.GetNextSpawn(mvpTimer, mvpInfo);
        var nextSpawnWindowEnd = SpawnCalculator.GetNextSpawnWindowEnd(mvpTimer, mvpInfo);
        var nextReminder = SpawnCalculator.GetNextReminder(mvpTimer, mvpInfo);

        var buttonBuilder = new ComponentBuilder()
            .WithButton("Override?", overrideCustomId, ButtonStyle.Primary);

        var embedBuilder = new EmbedBuilder()
            .WithUrl(ArcadiaRoUrlBuilder.GetMobInfoUrl(mvpInfo.RagnarokId.ToString()))
            .WithThumbnailUrl(ArcadiaRoUrlBuilder.GetMobImageUrl(mvpInfo.RagnarokId.ToString()))
            .WithTitle(mvpInfo.MvpName)
            .AddField("Map", mvpInfo.Map, true)
            .AddField("Spawn time", $"<t:{nextSpawn.ToEpoch()}:t> to <t:{nextSpawnWindowEnd.ToEpoch()}:t>\n<t:{nextSpawn.ToEpoch()}:R>", true)
            .AddField("Reminder", $"<t:{nextReminder.ToEpoch()}:t>", true);

        return new DiscordMessage(message: "# Override this timer?", embed: embedBuilder.Build(), ephemeral: true, messageComponent: buttonBuilder.Build());
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
}