using System;
using System.Text.RegularExpressions;
using RagnaBot.Exceptions;

namespace RagnaBot.Utils
{
    public class TimeOfDeathParser
    {
        public static DateTime Parse(
            string timeOfDeath
        )
        {
            if (string.IsNullOrEmpty(timeOfDeath))
                return DateTime.UtcNow;

            var tombFormat = Regex.Match(timeOfDeath, "^([0-9]|[0-1][0-9]|2[0-3])[:h]?([0-5][0-9])$");
            if (tombFormat.Success)
            {
                var hours = Convert.ToInt32(tombFormat.Groups[1].Value);
                var minutes = Convert.ToInt32(tombFormat.Groups[2].Value);

                var timeSpanOfDeath = TimeSpan.FromMinutes(hours * 60 + minutes);

                return DateTime.UtcNow.TimeOfDay >= timeSpanOfDeath
                    ? DateTime.UtcNow.Date.Add(timeSpanOfDeath)
                    : DateTime.UtcNow.Date.AddDays(-1).Add(timeSpanOfDeath);
            }

            var agoFormat = Regex.Match(timeOfDeath, "^([1-9][0-9]*)m$");
            if (agoFormat.Success)
            {
                var minutesAgo = Convert.ToInt32(agoFormat.Groups[1].Value);

                return DateTime.UtcNow.AddMinutes(-minutesAgo);
            }

            throw new InvalidTimeOfDeathFormatException();
        }
    }
}