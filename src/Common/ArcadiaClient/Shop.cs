using System;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json.Serialization;

public record Shop
{
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("owner")]
    public required string Owner { get; init; }

    [JsonPropertyName("location")]
    public required Location Location { get; init; }

    [JsonPropertyName("creation_date")]
    public required DateTime CreationDate { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("items")]
    public required ImmutableList<ShopItem> Items { get; init; }

    public string GetShopId()
    {
        return $"{Owner}_{CreationDate:yyyyMMddHHmmss}";
    }

    public override string ToString()
    {
        return $"Title: {Title}, Owner: {Owner}, Location: {Location}, CreationDate: {CreationDate}, Type: {Type}, Items: {string.Join(", ", Items.Select(i => i.ItemId))}";
    }
}