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
            return new DiscordMessageBuilder()
                .WithContent(
                    $"**{mvpInfo.MvpName}** on map `{mvpInfo.Map}` will spawn <t:{nextSpawn.ToEpoch()}:R> with a variance of {mvpInfo.RespawnVariance.TotalMinutes} minutes.\n" +
                    $"A reminder will occur {mvpInfo.RespawnReminder.TotalMinutes} minutes before spawn window."
                );
        }

        public static DiscordMessageBuilder MvpSpawningSoon(
            Config config,
            Timer timer,
            MvpInfo mvpInfo,
            IEnumerable<DiscordRole> mentions
        )
        {
            var nextSpawn = SpawnCalculator.GetNextSpawn(timer, mvpInfo);
            return new DiscordMessageBuilder()
                .WithContent(
                    $"**{mvpInfo.MvpName}** on map `{mvpInfo.Map}` will spawn in <t:{nextSpawn.ToEpoch()}:R> with a variance of {mvpInfo.RespawnVariance.TotalMinutes} minutes.\n" +
                    string.Join("\n", mentions.Select(m => m.Mention))
                )
                .WithAllowedMention(new RoleMention(config.TrackerRoleId))
                .WithAllowedMention(new RoleMention(config.HighEndMvpTeamRoleId));
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