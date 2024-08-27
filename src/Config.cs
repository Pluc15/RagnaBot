using System;
using System.ComponentModel.DataAnnotations;

public class Config
{
    [Required]
    public required ulong MarketTrackerChannelId { get; set; }

    [Required]
    public required ulong MvpTrackerChannelId { get; set; }

    [Required]
    public required ulong MvpTrackerRoleId { get; set; }

    [Required]
    public required ulong MvpHighEndTeamRoleId { get; set; }

    [Required]
    public required string DiscordBotToken { get; set; }

    [Required]
    public required string ArcadiaApiToken { get; set; }

    [Required]
    public required string SaveFile { get; set; }

    [Required]
    public required string MarketSaveFile { get; set; }

    [Required]
    public required Uri ArcadiaBaseUrl { get; set; }
}