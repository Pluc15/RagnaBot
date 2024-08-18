using System.Text.Json.Serialization;

namespace RagnaBot.Origin
{
    public class Location
    {
        [JsonPropertyName("map")]
        public string Map { get; set; }

        [JsonPropertyName("x")]
        public int X { get; set; }

        [JsonPropertyName("y")]
        public int Y { get; set; }
    }
}