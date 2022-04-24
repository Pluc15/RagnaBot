using System.Collections.Generic;
using RagnaBot.Data;

namespace RagnaBot.Models
{
    public class DatabaseModel
    {
        public List<Timer> Timers { get; set; } = new();

        public Dictionary<int, ulong> DashboardMessageIds { get; set; } = new();

        public List<MessageReference> MessagesToCleanup { get; set; } = new();
    }
}