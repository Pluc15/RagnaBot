namespace RagnaBot
{
    public class Config
    {
        public ulong ChannelId { get; set; }
        public ulong TrackerRoleId { get; set; }
        public string DiscordBotToken { get; set; }
        public string SaveFile { get; set; }
        public string[] CommandPrefix { get; set; }
    }
}