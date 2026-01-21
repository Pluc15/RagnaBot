using System.Collections.Generic;

public class DatabaseModel
{
    public ConfigModel Config { get; set; } = new();

    public List<MvpTimer> MvpTimers { get; set; } = [];

    public Dictionary<int, MvpDashboardMessage> MvpDashboardMessages { get; set; } = [];

    public List<MvpMessageReference> MvpMessagesToCleanup { get; set; } = [];

    public List<MarketWatcher> MarketWatchers { get; set; } = [];

    public List<VendorWatcher> VendorWatchers { get; set; } = [];
}
