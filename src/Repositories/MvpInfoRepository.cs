using System.Collections.Generic;
using System.Linq;

public class MvpInfoRepository(MvpInfoDatabase database)
{
    public MvpInfo? Find(
        string mvpId
    )
    {
        return database.Data.SingleOrDefault(m => m.Id == mvpId);
    }

    public IEnumerable<MvpInfo> Search(
        string search
    )
    {
        return database.Data.Where(m => m.MvpName.StartsWith(search, System.StringComparison.InvariantCultureIgnoreCase));
    }
}
