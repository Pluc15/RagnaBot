using System.Linq;

public class MarketListingRepository(MarketDatabase db)
{
    public (Shop Shop, ShopItem ShopItem) GetMarketLowestPrice(
        int itemId
    )
    {
        return db
            .Data
            .Shops
            .SelectMany(
                s => s.Items,
                (
                    shop,
                    item
                ) =>
                {
                    return (Shop: shop, ShopItem: item);
                })
            .Where(l => l.ShopItem.ItemId == itemId)
            .OrderBy(l => l.ShopItem.Price)
            .FirstOrDefault();
    }

    public void Update(Market marketListing)
    {
        db.Data = marketListing;
    }
}
