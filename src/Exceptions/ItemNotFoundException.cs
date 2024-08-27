using System;

public class ItemInfoNotFoundException(int itemId) : Exception($"Item info not found for id '{itemId}'.")
{
    public int ItemId { get; } = itemId;
}
