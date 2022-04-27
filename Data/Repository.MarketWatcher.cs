using System;
using System.Collections.Generic;
using System.Linq;
using RagnaBot.Models;

namespace RagnaBot.Data
{
    public partial class Repository
    {
        public void AddOrReplaceMarketWatcher(
            ulong userId,
            int itemId,
            int maximumPrice
        )
        {
            var existing = _data.MarketWatchers.SingleOrDefault(w => w.UserId == userId && w.ItemId == itemId);
            if (existing == null)
            {
                _data.MarketWatchers.Add(
                    new MarketWatcher
                    {
                        UserId = userId,
                        ItemId = itemId,
                        MaximumPrice = maximumPrice
                    }
                );
            }
            else
            {
                existing.UserId = userId;
                existing.ItemId = itemId;
                existing.MaximumPrice = maximumPrice;
            }

            _dirty = true;
        }

        public int DeleteMarketWatcher(
            ulong userId,
            int itemId
        )
        {
            var deletedCount = _data.MarketWatchers.RemoveAll(w => w.UserId == userId && w.ItemId == itemId);
            _dirty = true;
            return deletedCount;
        }

        public List<MarketWatcher> GetAllMarketWatchers(
        )
        {
            return _data.MarketWatchers.ToList();
        }

        public void SnoozeWatcher(
            ulong userId,
            int itemId,
            TimeSpan snoozeDuration
        )
        {
            var watcher = _data.MarketWatchers.Single(o => o.UserId == userId && o.ItemId == itemId);
            watcher.SnoozedUntil = DateTime.UtcNow.Add(snoozeDuration);
            _dirty = true;
        }
    }
}