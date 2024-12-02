public class ItemInfoRepository(ItemInfoDatabase database)
{
    public ItemInfo? Search(
        int itemId
    )
    {
        return database.Data.TryGetValue(itemId, out var item) ? item : null;
    }
}