using System;

public class MvpInvalidTimeOfDeathFormatException : Exception
{
    public MvpInvalidTimeOfDeathFormatException(
    ) : base("The time of death needs to be in 'HH:MM', 'HHMM' or 'MMm' (ago) format.")
    {
    }
}