using System.Collections.Generic;

public class DatabaseModel
{
    public List<MvpTimer> MvpTimers { get; set; } = [];

    public Dictionary<int, ulong> MvpDashboardMessageIds { get; set; } = [];

    public List<MvpMessageReference> MvpMessagesToCleanup { get; set; } = [];

    public List<MarketWatcher> MarketWatchers { get; set; } = [];
}