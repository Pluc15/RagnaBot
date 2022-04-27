using System;

namespace RagnaBot
{
    public class Config
    {
        public ulong MarketTrackerChannelId { get; set; }
        public ulong MvpTrackerChannelId { get; set; }
        public ulong MvpTrackerRoleId { get; set; }
        public ulong HighEndMvpTeamRoleId { get; set; }
        public string DiscordBotToken { get; set; }
        public string SaveFile { get; set; }
        public string MarketSaveFile { get; set; }
        public string[] CommandPrefix { get; set; }
        public string OriginApiToken { get; set; }
        public Uri OriginBaseUrl { get; set; }
    }
}