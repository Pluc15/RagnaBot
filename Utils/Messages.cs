using RagnaBot.Data;

namespace RagnaBot.Utils
{
    public static class Messages
    {
        public static string TimerRegistered(
            Timer timer
        )
        {
            var spawn = timer.NextSpawn.HasValue
                ? $"<t:{timer.NextSpawn.Value.ToEpoch()}:R>"
                : "`null`";
            return
                $"**{timer.MvpName}** on map `{timer.Map}` will spawn {spawn} with a variance of {timer.RespawnVariance.TotalMinutes} minutes.\n" +
                $"A reminder will occur {timer.RespawnReminder.TotalMinutes} minutes before spawn window.";
        }

        public static string MvpSpawningSoon(
            Timer timer,
            ulong trackerRoleId
        )
        {
            var spawn = timer.NextSpawn.HasValue
                ? $"<t:{timer.NextSpawn.Value.ToEpoch()}:R>"
                : "`null`";
            return
                $"**{timer.MvpName}** on map `{timer.Map}` will spawn in {spawn} with a variance of {timer.RespawnVariance.TotalMinutes} minutes.\n" +
                $"<@&{trackerRoleId}>";
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