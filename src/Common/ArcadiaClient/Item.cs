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
    public int? Refine { get; init; }

    [JsonPropertyName("cards")]
    public List<int>? Cards { get; init; }

    [JsonPropertyName("star_crumbs")]
    public int? StarCrumbs { get; init; }

    [JsonPropertyName("element")]
    public string? Element { get; init; }

    [JsonPropertyName("creator")]
    public int? Creator { get; init; }

    [JsonPropertyName("beloved")]
    public Boolean? Beloved { get; init; }
}