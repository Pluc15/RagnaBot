using System;

namespace RagnaBot.Exceptions
{
    public class InvalidTimeOfDeathFormatException : Exception
    {
        public InvalidTimeOfDeathFormatException(
        ) : base("The time of death needs to be in 'HH:MM', 'HHMM' or 'MMm' (ago) format.")
        {
        }
    }
}