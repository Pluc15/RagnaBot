using System;

namespace RagnaBot.Data
{
    public class Timer
    {
        public string Id { get; set; }

        public DateTime TimeOfDeath { get; set; }

        public bool ReminderSent { get; set; }

        public ulong ReportedByUserId { get; set; }
    }
}