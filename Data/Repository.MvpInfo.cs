using System.Linq;
using RagnaBot.Models;

namespace RagnaBot.Data
{
    public partial class Repository
    {
        public MvpInfo SearchMvpInfo(
            string mvpKey
        )
        {
            return MvpInfo.Mvps.SingleOrDefault(m => m.MvpKeys.Contains(mvpKey));
        }
    }
}