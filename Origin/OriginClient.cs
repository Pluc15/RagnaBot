using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RagnaBot.Origin
{
    public class OriginClient
    {
        private readonly HttpClient _httpClient;
        private readonly Config _config;

        public OriginClient(HttpClient httpClient, Config config)
        {
            _httpClient = httpClient;
            _config = config;
            _httpClient.BaseAddress = config.OriginBaseUrl;
            _httpClient.DefaultRequestHeaders.Add("x-api-key", config.OriginApiToken);
        }

        public async Task<Market> GetMarketListing()
        {
            var response = await _httpClient.GetAsync("market/list");
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Market>(body);
        }
    }
}