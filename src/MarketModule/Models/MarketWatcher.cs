using System.Collections.Generic;

public class MarketWatcher
{
    public ulong UserId { get; set; }

    public int ItemId { get; set; }

    public int MaximumPrice { get; set; }

    public int MinimumQuantity { get; set; } = 1; // Default value for backward compatibility when loading old watchers

    public List<string> ShopsNotified { get; set; } = [];

    public override string ToString()
    {
        return $"UserId: {UserId}, ItemId: {ItemId}, MaximumPrice: {MaximumPrice}, MinimumQuantity: {MinimumQuantity}, ShopsNotified: [{string.Join(", ", ShopsNotified)}]";
    }
}