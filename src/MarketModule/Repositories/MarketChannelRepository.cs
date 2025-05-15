public class MarketConfigRepository(Database db)
{
    public ulong? GetMarketTrackerChannelId()
    {
        return db.Data.Config.MarketTrackerChannelId;
    }

    public void SetMarketTrackerChannelId(ulong? id)
    {
        db.Data.Config.MarketTrackerChannelId = id;
        db.Dirty = true;
    }
}