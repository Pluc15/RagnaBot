using System;

namespace RagnaBot.Models
{
    public class MarketWatcher
    {
        public ulong UserId { get; set; }

        public int ItemId { get; set; }

        public int MaximumPrice { get; set; }

        public DateTime? SnoozedUntil { get; set; }
    }
}