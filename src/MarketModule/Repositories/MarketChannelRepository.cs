public class MarketConfigRepository(Database db)
{
    public ulong GetMarketTrackerChannelId()
    {
        return db.Data.Config.MarketTrackerChannelId;
    }
}