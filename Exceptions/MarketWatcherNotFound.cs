using System;

namespace RagnaBot.Exceptions
{
    public class MarketWatcherNotFound : Exception
    {
        public MarketWatcherNotFound() : base("Market watcher not found.")
        {
        }
    }
}