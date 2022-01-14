using System;
using Newtonsoft.Json;

namespace RagnaBot.Data
{
    public class Timer
    {
        public string[] MvpKeys { get; set; }

        public string MvpName { get; set; }

        public string Map { get; set; }

        public int RagnarokId { get; set; }

        public int Page { get; set; }

        public TimeSpan RespawnDuration { get; set; }

        public TimeSpan RespawnVariance { get; set; }

        public TimeSpan RespawnReminder { get; set; }

        public DateTime? TimeOfDeath { get; set; }

        public bool ReminderSent { get; set; }

        [JsonIgnore]
        public DateTime? NextSpawn => TimeOfDeath + RespawnDuration;

        [JsonIgnore]
        public DateTime? NextReminder => ReminderSent ? null : TimeOfDeath + RespawnDuration - RespawnReminder;

        [JsonIgnore]
        public bool IsReminderDue => !ReminderSent && NextReminder <= DateTime.UtcNow;

        [JsonIgnore]
        public bool IsOldTimer => NextSpawn <= DateTime.UtcNow.AddHours(-12);
    }
}