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
}