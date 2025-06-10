using System;
using System.Linq;
using System.Threading.Tasks;
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using Microsoft.Extensions.Options;

public class MarketListingRepository(MarketDatabase db, IOptions<Config> config)
{
    public (Shop Shop, ShopItem ShopItem) GetMarketLowestPrice(
        int itemId,
        int maximumPrice,
        int minimumQuantity
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
            .Where(l =>
                l.Shop.Type == "V" &&
                l.ShopItem.ItemId == itemId &&
                l.ShopItem.Price <= maximumPrice &&
                l.ShopItem.Amount >= minimumQuantity
            )
            .OrderBy(l => l.ShopItem.Price)
            .FirstOrDefault();
    }

    public async Task UpdateAsync(Market marketListing)
    {
        db.Data = marketListing;

        try
        {
            using var influxDBClient = new InfluxDBClient($"{config.Value.InfluxDbUrl}?org=ragnabot&bucket=ragnabot&token={config.Value.InfluxDbToken}");
            var writeApiAsync = influxDBClient.GetWriteApiAsync();
            var utcNow = DateTime.UtcNow;

            foreach (var shop in marketListing.Shops)
            {
                foreach (var item in shop.Items)
                {
                    var point = PointData
                        .Measurement("market_listing")
                        .Tag("shop_id", shop.Owner + "_" + shop.CreationDate.Ticks.ToString())
                        .Tag("shop_owner", shop.Owner)
                        .Tag("shop_creation_date", shop.CreationDate.ToString())
                        .Tag("shop_title", shop.Title)
                        .Tag("shop_location_map", shop.Location.Map)
                        .Tag("shop_location_x", shop.Location.X.ToString())
                        .Tag("shop_location_y", shop.Location.Y.ToString())
                        .Tag("shop_type", shop.Type)
                        .Tag("item_id", item.ItemId.ToString())
                        .Field("item_price", item.Price)
                        .Timestamp(utcNow, WritePrecision.Ns);

                    await writeApiAsync.WritePointAsync(point);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
