using System;

namespace RagnaBot
{
    public class Config
    {
        public ulong ChannelId { get; set; }
        public ulong TrackerRoleId { get; set; }
        public ulong HighEndMvpTeamRoleId { get; set; }
        public string DiscordBotToken { get; set; }
        public string SaveFile { get; set; }
        public string[] CommandPrefix { get; set; }
        public string OriginApiToken { get; set; }
        public Uri OriginBaseUrl { get; set; }
    }
}