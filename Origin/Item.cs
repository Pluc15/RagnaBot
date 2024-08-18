using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RagnaBot.Origin
{
    public class Item
    {
        [JsonPropertyName("item_id")]
        public int ItemId { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("refine")]
        public int? Refine { get; set; }

        [JsonPropertyName("cards")]
        public List<int> Cards { get; set; }

        [JsonPropertyName("star_crumbs")]
        public int? StarCrumbs { get; set; }

        [JsonPropertyName("element")]
        public string? Element { get; set; }

        [JsonPropertyName("creator")]
        public int? Creator { get; set; }

        [JsonPropertyName("beloved")]
        public Boolean? Beloved { get; set; }
    }
}