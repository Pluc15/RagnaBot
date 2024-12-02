using System;

public class MvpTimer
{
    public required string Id { get; init; }

    public required DateTime TimeOfDeath { get; init; }

    public required bool ReminderSent { get; set; }

    public required ulong ReportedByUserId { get; init; }
}