namespace RagnaBot.Data
{
    public partial class Repository
    {
        public bool HasDashboardMessageId(
            int page
        )
        {
            return _data.DashboardMessageIds.ContainsKey(page);
        }

        public ulong GetDashboardMessageId(
            int page
        )
        {
            return _data.DashboardMessageIds[page];
        }

        public void UpdateDashboardMessageId(
            int page,
            ulong messageId
        )
        {
            _data.DashboardMessageIds[page] = messageId;
            _dirty = true;
        }
    }
}