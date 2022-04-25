using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RagnaBot.Origin
{
    public class Shop
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("creation_date")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }
    }
}