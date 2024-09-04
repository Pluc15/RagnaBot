using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public class UpdateMvpDashboardAction(
    IOptions<Config> config,
    DiscordSocketClient discordClient,
    MvpDashboardRepository mvpDashboardRepository,
    MvpTimersRepository mvpTimersRepository,
    ILogger<UpdateMvpDashboardAction> logger)
{
    public async Task Run()
    {
        var channel = await discordClient.GetChannelAsync(config.Value.MvpTrackerChannelId) as IMessageChannel ?? throw new Exception("Mvp channel not found");
        await InitDashboard(channel);
        await UpdateDashboardSpawned(channel, mvpDashboardRepository.GetDashboardMessageId(0));
        await UpdateDashboardInWindow(channel, mvpDashboardRepository.GetDashboardMessageId(1));
        await UpdateDashboardSpawningSoon(channel, mvpDashboardRepository.GetDashboardMessageId(2));
        await UpdateDashboardSpawningInAWhile(channel, mvpDashboardRepository.GetDashboardMessageId(3));

        logger.LogInformation("Mvp Dashboard updated.");
    }

    public async Task InitDashboard(IMessageChannel channel)
    {
        if (!mvpDashboardRepository.HasDashboardMessageId(0))
            mvpDashboardRepository.UpdateDashboardMessageId(0, (await channel.SendMessageAsync("Dashboard placeholder 1")).Id);
        if (!mvpDashboardRepository.HasDashboardMessageId(1))
            mvpDashboardRepository.UpdateDashboardMessageId(1, (await channel.SendMessageAsync("Dashboard placeholder 2")).Id);
        if (!mvpDashboardRepository.HasDashboardMessageId(2))
            mvpDashboardRepository.UpdateDashboardMessageId(2, (await channel.SendMessageAsync("Dashboard placeholder 3")).Id);
        if (!mvpDashboardRepository.HasDashboardMessageId(3))
            mvpDashboardRepository.UpdateDashboardMessageId(3, (await channel.SendMessageAsync("Dashboard placeholder 4")).Id);
    }

    private async Task UpdateDashboardSpawned(
        IMessageChannel channel,
        ulong messageId
    )
    {
        var timersSpawned = mvpTimersRepository.GetTimersSpawned();
        var discordMessage = DiscordMessages.MvpDashboard("MVPs Recently Spawned", timersSpawned);
        await DiscordMessages.Modify(channel, messageId, discordMessage);
    }

    private async Task UpdateDashboardInWindow(
        IMessageChannel channel,
        ulong messageId
    )
    {
        var timersSpawned = mvpTimersRepository.GetTimersInWindow();
        var discordMessage = DiscordMessages.MvpDashboard("MVPs In Window", timersSpawned);
        await DiscordMessages.Modify(channel, messageId, discordMessage);
    }

    private async Task UpdateDashboardSpawningSoon(
        IMessageChannel channel,
        ulong messageId
    )
    {
        var timersSpawned = mvpTimersRepository.GetTimersSpawningSoon();
        var discordMessage = DiscordMessages.MvpDashboard("MVPs Spawning Soon", timersSpawned);
        await DiscordMessages.Modify(channel, messageId, discordMessage);
    }

    private async Task UpdateDashboardSpawningInAWhile(
        IMessageChannel channel,
        ulong messageId
    )
    {
        var timersSpawned = mvpTimersRepository.GetTimersSpawningInAWhile();
        var discordMessage = DiscordMessages.MvpDashboard("MVPs Spawning In A While", timersSpawned);
        await DiscordMessages.Modify(channel, messageId, discordMessage);
    }
}