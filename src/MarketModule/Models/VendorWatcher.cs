public record class VendorWatcher
{
    public required ulong UserId { get; init; }

    public required string VendorName { get; init; }

    public Shop? LastKnownShop { get; init; }

    public override string ToString()
    {
        return $"UserId: {UserId}, VendorName: {VendorName}, LastKnownState: {(LastKnownShop == null ? "Unknown" : "Known")}";
    }
}