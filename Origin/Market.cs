using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RagnaBot.Origin
{
    public class Market
    {
        [JsonPropertyName("shops")]
        public IList<Shop> Shops { get; set; }
    }
}