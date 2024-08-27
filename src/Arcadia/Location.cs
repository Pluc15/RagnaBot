using System.Text.Json.Serialization;

public record Location
{
    [JsonPropertyName("map")]
    public required string Map { get; init; }

    [JsonPropertyName("x")]
    public required int X { get; init; }

    [JsonPropertyName("y")]
    public required int Y { get; init; }
}