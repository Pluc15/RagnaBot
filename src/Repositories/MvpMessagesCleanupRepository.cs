using System;
using System.Collections.Generic;
using System.Linq;

public class MvpMessagesCleanupRepository(Database db)
{
    public void Add(
        ulong id,
        DateTime deletionTime,
        string? mvpId
    )
    {
        db.Data.MvpMessagesToCleanup.Add(
            new MvpMessageReference
            {
                Id = id,
                DeletionTime = deletionTime,
                MvpId = mvpId
            }
        );
        db.Dirty = true;
    }

    public IEnumerable<MvpMessageReference> GetExpired()
    {
        return db.Data.MvpMessagesToCleanup
            .Where(m => m.DeletionTime < DateTime.UtcNow)
            .ToList();
    }

    public IEnumerable<MvpMessageReference> GetForMvpId(
        string mvpId
    )
    {
        return db.Data.MvpMessagesToCleanup
            .Where(m => m.MvpId == mvpId)
            .ToList();
    }

    public void RemoveMessageToCleanup(
        MvpMessageReference mvpMessageReference
    )
    {
        db.Data.MvpMessagesToCleanup.Remove(mvpMessageReference);
        db.Dirty = true;
    }
}
