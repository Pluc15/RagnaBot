using System.Linq;

public class MvpInfoRepository(MvpInfoDatabase database)
{
    public MvpInfo? Search(
        string mvpKey
    )
    {
        return database.Data.SingleOrDefault(m => m.MvpKeys.Contains(mvpKey));
    }
}
