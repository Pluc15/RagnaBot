using System;

public static class DateTimeExtensions
{
    private static readonly DateTime EpochDateTime = new(1970, 1, 1);

    public static int ToEpoch(
        this DateTime dateTime
    )
    {
        var timeSinceEpoch = dateTime - EpochDateTime;
        return (int)timeSinceEpoch.TotalSeconds;
    }
}