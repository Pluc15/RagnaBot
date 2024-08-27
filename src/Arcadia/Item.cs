using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public record ShopItem
{
    [JsonPropertyName("item_id")]
    public required int ItemId { get; init; }

    [JsonPropertyName("amount")]
    public required int Amount { get; init; }

    [JsonPropertyName("price")]
    public required int Price { get; init; }

    [JsonPropertyName("refine")]
    public required int? Refine { get; init; }

    [JsonPropertyName("cards")]
    public required List<int> Cards { get; init; }

    [JsonPropertyName("star_crumbs")]
    public required int? StarCrumbs { get; init; }

    [JsonPropertyName("element")]
    public required string? Element { get; init; }

    [JsonPropertyName("creator")]
    public required int? Creator { get; init; }

    [JsonPropertyName("beloved")]
    public required Boolean? Beloved { get; init; }
}