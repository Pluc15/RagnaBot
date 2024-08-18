using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RagnaBot.Origin;

namespace RagnaBot.Data
{
    public partial class Repository
    {
        private List<(Shop Shop, Item Item)> _marketItems;
        private Market _market;

        public async Task LoadMarketListing()
        {
            if (File.Exists(_config.MarketSaveFile))
            {
                var loadData = await File.ReadAllTextAsync(_config.MarketSaveFile);
                _market = JsonConvert.DeserializeObject<Market>(loadData);
                ComputeMarket();
            }
        }

        public async Task SaveMarketListing()
        {
            await _saveRetryPolicy.Execute(
                async () =>
                {
                    var data = JsonConvert.SerializeObject(_market, Formatting.Indented, JsonSerializerSettings);
                    await File.WriteAllTextAsync(_config.MarketSaveFile, data);
                }
            );
            _logger.LogInformation("Market Data saved");
        }

        public void UpdateMarketListing(
            Market marketListing
        )
        {
            _market = marketListing;
            ComputeMarket();
        }

        public (Shop Shop, Item Item) GetMarketLowestPrice(
            int itemId
        )
        {
            return _marketItems
                .Where(l => l.Item.ItemId == itemId)
                .OrderBy(l => l.Item.Price)
                .FirstOrDefault();
        }

        private void ComputeMarket()
        {
            _marketItems = _market.Shops
                .SelectMany(
                    s => s.Items,
                    (
                        shop,
                        item
                    ) => (shop, item)
                )
                .ToList();
        }
    }
}