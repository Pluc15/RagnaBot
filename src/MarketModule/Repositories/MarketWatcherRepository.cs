using System;
using System.Collections.Generic;
using System.Linq;

public class MarketWatcherRepository(MvpDatabase db)
{
    public MarketWatcher AddOrReplace(
        ulong userId,
        int itemId,
        int maximumPrice
    )
    {
        var watcher = db.Data.MarketWatchers.SingleOrDefault(w => w.UserId == userId && w.ItemId == itemId);
        if (watcher == null)
        {
            watcher = new MarketWatcher
            {
                UserId = userId,
                ItemId = itemId,
                MaximumPrice = maximumPrice
            };
            db.Data.MarketWatchers.Add(watcher);
        }
        else
        {
            watcher.UserId = userId;
            watcher.ItemId = itemId;
            watcher.MaximumPrice = maximumPrice;
        }

        db.Dirty = true;

        return watcher;
    }

    public int Delete(
        ulong userId,
        int itemId
    )
    {
        var deletedCount = db.Data.MarketWatchers.RemoveAll(w => w.UserId == userId && w.ItemId == itemId);
        db.Dirty = true;
        return deletedCount;
    }

    public List<MarketWatcher> GetAllMarketWatchers(
    )
    {
        return db.Data.MarketWatchers.ToList();
    }

    public void Snooze(
        ulong userId,
        int itemId,
        TimeSpan snoozeDuration
    )
    {
        var watcher = db.Data.MarketWatchers.Single(o => o.UserId == userId && o.ItemId == itemId);
        watcher.SnoozedUntil = DateTime.UtcNow.Add(snoozeDuration);
        db.Dirty = true;
    }

    public List<MarketWatcher> GetForUser(
        ulong userId
    )
    {
        return db.Data.MarketWatchers
            .Where(w => w.UserId == userId)
            .ToList();
    }
}