using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

public class ArcadiaClient
{
    private readonly HttpClient _httpClient;

    public ArcadiaClient(
        IOptions<Config> config,
        HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = config.Value.ArcadiaBaseUrl;
        _httpClient.DefaultRequestHeaders.Add("x-api-key", config.Value.ArcadiaApiToken);
    }

    public async Task<Market> GetMarketListing()
    {
        var response = await _httpClient.GetAsync("market/list");
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Market>(body) ?? throw new Exception("Failed to deserialize the Market from the API.");
    }

    public Task<Market> GetMarketListingSampleData()
    {
        var body = File.ReadAllText($"SampleData/market_response_sample.json");
        return Task.FromResult(JsonSerializer.Deserialize<Market>(body) ?? throw new Exception("Failed to deserialize the Market from the API."));
    }

    public Market BuildFakeData()
    {
        return new Market
        {
            Shops = [
                new Shop
                {
                    Title = "esrwg",
                    Owner = "srge",
                    Location = new Location
                    {
                        Map = "asd",
                        X = 123,
                        Y = 524,
                    },
                    CreationDate = DateTime.UtcNow,
                    Type = "idk",
                    Items = [
                        new ShopItem
                        {
                            ItemId = 1112,
                            Amount = 14,
                            Price = 10,
                            Refine = null,
                            Cards = [],
                            StarCrumbs = null,
                            Element = null,
                            Creator = null,
                            Beloved = null
                        }
            ],
                }]
        };
    }
}