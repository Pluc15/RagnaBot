using System.Collections.Generic;
using System.Linq;
using DSharpPlus.Entities;
using RagnaBot.Models;

namespace RagnaBot.Utils
{
    public static class Messages
    {
        public static DiscordMessageBuilder TimerRegistered(
            Timer timer,
            MvpInfo mvpInfo
        )
        {
            var nextSpawn = SpawnCalculator.GetNextSpawn(timer, mvpInfo);
            var nextSpawnWindowEnd = SpawnCalculator.GetNextSpawnWindowEnd(timer, mvpInfo);
            var nextReminder = SpawnCalculator.GetNextReminder(timer, mvpInfo);
            return new DiscordMessageBuilder()
                .AddEmbed(
                    new DiscordEmbedBuilder()
                        .WithUrl(OriginsRoUrlBuilder.GetMobInfoUrl(mvpInfo.RagnarokId.ToString()))
                        .WithThumbnail(OriginsRoUrlBuilder.GetMobImageUrl(mvpInfo.RagnarokId.ToString()))
                        .WithTitle(mvpInfo.MvpName)
                        .AddField("Map", mvpInfo.Map, true)
                        .AddField("Spawn time", $"<t:{nextSpawn.ToEpoch()}:t> to <t:{nextSpawnWindowEnd.ToEpoch()}:t>\n<t:{nextSpawn.ToEpoch()}:R>", true)
                        .AddField("Reminder", $"<t:{nextReminder.ToEpoch()}:t>", true)
                );
        }

        public static DiscordMessageBuilder MvpSpawningSoon(
            Timer timer,
            MvpInfo mvpInfo,
            IEnumerable<DiscordRole> mentionRoles
        )
        {
            var nextSpawn = SpawnCalculator.GetNextSpawn(timer, mvpInfo);
            var nextSpawnWindowEnd = SpawnCalculator.GetNextSpawnWindowEnd(timer, mvpInfo);
            var discordMessageBuilder = new DiscordMessageBuilder()
                .AddEmbed(
                    new DiscordEmbedBuilder()
                        .WithUrl(OriginsRoUrlBuilder.GetMobInfoUrl(mvpInfo.RagnarokId.ToString()))
                        .WithThumbnail(OriginsRoUrlBuilder.GetMobImageUrl(mvpInfo.RagnarokId.ToString()))
                        .WithTitle(mvpInfo.MvpName)
                        .AddField("Map", mvpInfo.Map, true)
                        .AddField("Spawn time", $"<t:{nextSpawn.ToEpoch()}:t> to <t:{nextSpawnWindowEnd.ToEpoch()}:t>\n<t:{nextSpawn.ToEpoch()}:R>", true)
                        .AddField(
                            "Mentions",
                            string.Join(
                                "\n",
                                mentionRoles
                                    .Select(r => r.Mention)
                                    .Union(
                                        new[]
                                        {
                                            Formatter.FormatUserMention(timer.ReportedByUserId)
                                        }
                                    )
                            ),
                            true
                        )
                )
                .WithAllowedMention(new UserMention(timer.ReportedByUserId));
            foreach (var mention in mentionRoles)
                discordMessageBuilder.WithAllowedMention(new RoleMention(mention));
            return discordMessageBuilder;
        }

        public static DiscordMessageBuilder Dashboard(
            string title,
            IEnumerable<(Timer Timer, MvpInfo MvpInfo)> timersSpawned
        )
        {
            var embedBuilder = new DiscordEmbedBuilder()
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

            return new DiscordMessageBuilder()
                .AddEmbed(embedBuilder);
        }

        public static string UnknownMvp()
        {
            return "Unknown MvP";
        }

        public static string InvalidTimeOfDeathFormat()
        {
            return "The time of death needs to be in 'HH:MM', 'HHMM' or 'MMm' (ago) format.";
        }
    }
}