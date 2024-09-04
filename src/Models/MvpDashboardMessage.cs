using System.Collections.Generic;

public class MvpDashboardMessage
{
    public required ulong MessageId { get; set; }

    public required IEnumerable<string> MvpIds { get; set; }
}