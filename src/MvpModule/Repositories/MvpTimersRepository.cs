using System;
using System.Collections.Generic;
using System.Linq;
using Discord;

public class MvpTimersRepository(MvpDatabase database, MvpInfoDatabase mvpInfoDatabase)
{
    public IEnumerable<(MvpTimer Timer, MvpInfo MvpInfo)> GetTimersSpawningInAWhile()
    {
        return GetAllTimersWithMvpInfo()
            .Where(o => SpawnCalculator.IsSpawningInAWhile(o.Timer, o.MvpInfo))
            .ToList();
    }

    public IEnumerable<(MvpTimer Timer, MvpInfo MvpInfo)> GetTimersSpawningSoon()
    {
        return GetAllTimersWithMvpInfo()
            .Where(o => SpawnCalculator.IsSpawningSoon(o.Timer, o.MvpInfo))
            .ToList();
    }

    public IEnumerable<(MvpTimer Timer, MvpInfo MvpInfo)> GetTimersWithReminderDue()
    {
        return GetAllTimersWithMvpInfo()
            .Where(o => SpawnCalculator.IsReminderDue(o.Timer, o.MvpInfo))
            .ToList();
    }

    public IEnumerable<(MvpTimer Timer, MvpInfo MvpInfo)> GetTimersInWindow()
    {
        return GetAllTimersWithMvpInfo()
            .Where(o => SpawnCalculator.IsInWindow(o.Timer, o.MvpInfo))
            .ToList();
    }

    public IEnumerable<(MvpTimer Timer, MvpInfo MvpInfo)> GetTimersSpawned()
    {
        return GetAllTimersWithMvpInfo()
            .Where(o => SpawnCalculator.IsSpawned(o.Timer, o.MvpInfo))
            .ToList();
    }

    public IEnumerable<(MvpTimer Timer, MvpInfo MvpInfo)> GetTimersOldTimers()
    {
        return GetAllTimersWithMvpInfo()
            .Where(o => SpawnCalculator.IsOldTimer(o.Timer, o.MvpInfo))
            .ToList();
    }

    public void DeleteTimer(
        string id
    )
    {
        database.Data.MvpTimers.RemoveAll(t => t.Id == id);
        database.Dirty = true;
    }

    public void SetReminderSent(
        string id
    )
    {
        database.Data.MvpTimers.Single(t => t.Id == id).ReminderSent = true;
        database.Dirty = true;
    }

    public MvpTimer AddOrUpdate(
        MvpInfo mvpInfo,
        DateTime timeOfDeath,
        IUser user
    )
    {
        database.Data.MvpTimers.RemoveAll(t => t.Id == mvpInfo.Id);
        var timer = new MvpTimer
        {
            Id = mvpInfo.Id,
            TimeOfDeath = timeOfDeath,
            ReminderSent = false,
            ReportedByUserId = user.Id
        };
        database.Data.MvpTimers.Add(timer);
        database.Dirty = true;
        return timer;
    }

    public MvpTimer? GetExisting(MvpInfo mvpInfo)
    {
        return database.Data.MvpTimers.SingleOrDefault(t => t.Id == mvpInfo.Id);
    }

    private IEnumerable<(MvpTimer Timer, MvpInfo MvpInfo)> GetAllTimersWithMvpInfo()
    {
        return database.Data.MvpTimers.GroupJoin(
            mvpInfoDatabase.Data,
            t => t.Id,
            m => m.Id,
            (
                timer,
                mvpInfos
            ) => (timer, mvpInfos.Single())
        );
    }
}
