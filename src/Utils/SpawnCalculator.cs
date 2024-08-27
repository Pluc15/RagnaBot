using System;

public static class SpawnCalculator
{
    public static DateTime GetNextSpawn(
        MvpTimer timer,
        MvpInfo mvpInfo
    ) =>
        timer.TimeOfDeath + mvpInfo.RespawnDuration;

    public static DateTime GetNextSpawnWindowEnd(
        MvpTimer timer,
        MvpInfo mvpInfo
    ) =>
        timer.TimeOfDeath + mvpInfo.RespawnDuration + mvpInfo.RespawnVariance;

    public static DateTime GetNextReminder(
        MvpTimer timer,
        MvpInfo mvpInfo
    ) =>
        timer.TimeOfDeath + mvpInfo.RespawnDuration - mvpInfo.RespawnReminder;

    public static bool IsSpawningInAWhile(
        MvpTimer timer,
        MvpInfo mvpInfo
    ) =>
        GetNextReminder(timer, mvpInfo) > DateTime.UtcNow;

    public static bool IsSpawningSoon(
        MvpTimer timer,
        MvpInfo mvpInfo
    ) =>
        GetNextReminder(timer, mvpInfo) <= DateTime.UtcNow && GetNextSpawn(timer, mvpInfo) > DateTime.UtcNow;

    public static bool IsReminderDue(
        MvpTimer timer,
        MvpInfo mvpInfo
    ) =>
        !timer.ReminderSent && GetNextReminder(timer, mvpInfo) <= DateTime.UtcNow;

    public static bool IsInWindow(
        MvpTimer timer,
        MvpInfo mvpInfo
    ) =>
        GetNextSpawn(timer, mvpInfo) <= DateTime.UtcNow && GetNextSpawnWindowEnd(timer, mvpInfo) > DateTime.UtcNow;

    public static bool IsSpawned(
        MvpTimer timer,
        MvpInfo mvpInfo
    ) =>
        GetNextSpawnWindowEnd(timer, mvpInfo) <= DateTime.UtcNow;

    public static bool IsOldTimer(
        MvpTimer timer,
        MvpInfo mvpInfo
    ) =>
        GetNextSpawnWindowEnd(timer, mvpInfo) <= DateTime.UtcNow.Add(-(mvpInfo.RespawnDuration + mvpInfo.RespawnVariance));
}