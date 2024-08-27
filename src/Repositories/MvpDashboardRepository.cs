using System;

public class MvpDashboardRepository(Database database)
{
    public bool HasDashboardMessageId(
        int page
    )
    {
        if (database.Data == null) throw new Exception("Data not loaded.");
        return database.Data.MvpDashboardMessageIds.ContainsKey(page);
    }

    public ulong GetDashboardMessageId(
        int page
    )
    {
        if (database.Data == null) throw new Exception("Data not loaded.");
        return database.Data.MvpDashboardMessageIds[page];
    }

    public void UpdateDashboardMessageId(
        int page,
        ulong messageId
    )
    {
        if (database.Data == null) throw new Exception("Data not loaded.");
        database.Data.MvpDashboardMessageIds[page] = messageId;
        database.Dirty = true;
    }
}