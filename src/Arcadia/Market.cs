using System.Collections.Generic;
using System.Text.Json.Serialization;

public record Market
{
    [JsonPropertyName("shops")]
    public required IList<Shop> Shops { get; init; }
}