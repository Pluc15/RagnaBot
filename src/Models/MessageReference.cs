using System;

public class MvpMessageReference
{
    public required ulong Id { get; set; }

    public required DateTime DeletionTime { get; set; }

    public required string? MvpId { get; set; }
}