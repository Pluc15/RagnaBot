public class MvpConfigRepository(Database database)
{
    public ulong? GetMvpTrackerChannelId()
    {
        return database.Data.Config.MvpTrackerChannelId;
    }

    public ulong? GetMvpTrackerRoleId()
    {
        return database.Data.Config.MvpTrackerRoleId;
    }

    public void SetMvpTrackerChannelId(ulong? mvpTrackerChannelId)
    {
        database.Data.Config.MvpTrackerChannelId = mvpTrackerChannelId;
    }

    public void SetMvpTrackerRoleId(ulong? mvpTrackerRoleId)
    {
        database.Data.Config.MvpTrackerRoleId = mvpTrackerRoleId;
    }
}