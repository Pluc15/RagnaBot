using System;
using RagnaBot.Models;

namespace RagnaBot.Utils
{
    public static class SpawnCalculator
    {
        public static DateTime GetNextSpawn(
            Timer timer,
            MvpInfo mvpInfo
        ) =>
            timer.TimeOfDeath + mvpInfo.RespawnDuration;

        public static DateTime GetNextSpawnWindowEnd(
            Timer timer,
            MvpInfo mvpInfo
        ) =>
            timer.TimeOfDeath + mvpInfo.RespawnDuration + mvpInfo.RespawnVariance;

        public static DateTime GetNextReminder(
            Timer timer,
            MvpInfo mvpInfo
        ) =>
            timer.TimeOfDeath + mvpInfo.RespawnDuration - mvpInfo.RespawnReminder;

        public static bool IsSpawningInAWhile(
            Timer timer,
            MvpInfo mvpInfo
        ) =>
            GetNextReminder(timer, mvpInfo) > DateTime.UtcNow;

        public static bool IsSpawningSoon(
            Timer timer,
            MvpInfo mvpInfo
        ) =>
            GetNextReminder(timer, mvpInfo) <= DateTime.UtcNow && GetNextSpawn(timer, mvpInfo) > DateTime.UtcNow;

        public static bool IsReminderDue(
            Timer timer,
            MvpInfo mvpInfo
        ) =>
            !timer.ReminderSent && GetNextReminder(timer, mvpInfo) <= DateTime.UtcNow;

        public static bool IsInWindow(
            Timer timer,
            MvpInfo mvpInfo
        ) =>
            GetNextSpawn(timer, mvpInfo) <= DateTime.UtcNow && GetNextSpawnWindowEnd(timer, mvpInfo) > DateTime.UtcNow;

        public static bool IsSpawned(
            Timer timer,
            MvpInfo mvpInfo
        ) =>
            GetNextSpawnWindowEnd(timer, mvpInfo) <= DateTime.UtcNow;

        public static bool IsOldTimer(
            Timer timer,
            MvpInfo mvpInfo
        ) =>
            GetNextSpawnWindowEnd(timer, mvpInfo) <= DateTime.UtcNow.Add(-(mvpInfo.RespawnDuration + mvpInfo.RespawnVariance));
    }
}