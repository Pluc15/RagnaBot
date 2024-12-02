using System;
using System.Collections.Generic;

public class MvpDashboardRepository(MvpDatabase database)
{
    public bool HasDashboardMessage(
        int page
    )
    {
        if (database.Data == null) throw new Exception("Data not loaded.");
        return database.Data.MvpDashboardMessages.ContainsKey(page);
    }

    public MvpDashboardMessage GetDashboardMessage(
        int page
    )
    {
        if (database.Data == null) throw new Exception("Data not loaded.");
        return database.Data.MvpDashboardMessages[page];
    }

    public void UpdateDashboardMessageId(
        int page,
        ulong messageId
    )
    {
        if (database.Data == null) throw new Exception("Data not loaded.");
        database.Data.MvpDashboardMessages[page] = new MvpDashboardMessage
        {
            MessageId = messageId,
            MvpIds = []
        };
        database.Dirty = true;
    }

    public void UpdateDashboardMessageMvpIds(
        int page,
        IEnumerable<string> mvpIds
    )
    {
        if (database.Data == null) throw new Exception("Data not loaded.");
        database.Data.MvpDashboardMessages[page].MvpIds = mvpIds;
        database.Dirty = true;
    }
}