using System.Linq;
using RagnaBot.Models;

namespace RagnaBot.Data
{
    public partial class Repository
    {
        public MvpInfo GetMvpInfoById(
            string id
        )
        {
            return MvpInfo.Mvps.Single(m => m.Id == id);
        }

        public MvpInfo SearchMvpInfo(
            string mvpKey
        )
        {
            return MvpInfo.Mvps.SingleOrDefault(m => m.MvpKeys.Contains(mvpKey));
        }
    }
}