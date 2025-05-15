using System;

public class MvpInfo
{
    public required string Id { get; init; }

    public required string MvpName { get; init; }

    public required string Map { get; init; }

    public required int RagnarokId { get; init; }

    public required TimeSpan RespawnDuration { get; init; }

    public required TimeSpan RespawnVariance { get; init; }

    public required TimeSpan RespawnReminder { get; init; }
}