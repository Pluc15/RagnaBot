using System;
using System.Linq;

namespace RagnaBot.Data
{
    public partial class Repository : IDisposable
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