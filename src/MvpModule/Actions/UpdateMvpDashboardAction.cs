using System;
using System.Collections.Generic;
using System.Linq;
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
        await UpdateDashboard(channel, "MVPs Recently Spawned", 0, mvpTimersRepository.GetTimersSpawned());
        await UpdateDashboard(channel, "MVPs In Window", 1, mvpTimersRepository.GetTimersInWindow());
        await UpdateDashboard(channel, "MVPs Spawning Soon", 2, mvpTimersRepository.GetTimersSpawningSoon());
        await UpdateDashboard(channel, "MVPs Spawning In A While", 3, mvpTimersRepository.GetTimersSpawningInAWhile());
    }

    private async Task InitDashboard(IMessageChannel channel)
    {
        if (!mvpDashboardRepository.HasDashboardMessage(0))
            mvpDashboardRepository.UpdateDashboardMessageId(0, (await channel.SendMessageAsync("Dashboard placeholder 1")).Id);
        if (!mvpDashboardRepository.HasDashboardMessage(1))
            mvpDashboardRepository.UpdateDashboardMessageId(1, (await channel.SendMessageAsync("Dashboard placeholder 2")).Id);
        if (!mvpDashboardRepository.HasDashboardMessage(2))
            mvpDashboardRepository.UpdateDashboardMessageId(2, (await channel.SendMessageAsync("Dashboard placeholder 3")).Id);
        if (!mvpDashboardRepository.HasDashboardMessage(3))
            mvpDashboardRepository.UpdateDashboardMessageId(3, (await channel.SendMessageAsync("Dashboard placeholder 4")).Id);
    }

    private async Task UpdateDashboard(
        IMessageChannel channel,
        string title,
        int page,
        IEnumerable<(MvpTimer Timer, MvpInfo MvpInfo)> timers
    )
    {
        var mvpDashboardMessage = mvpDashboardRepository.GetDashboardMessage(page);
        // FIXME When you override a timer, the list is "same", would need to have death ticks in the hash set
        if (IsSameList(timers.Select(t => t.Timer.Id).ToHashSet(), mvpDashboardMessage.MvpIds.ToHashSet()))
            return;

        var discordMessage = DiscordMessages.MvpDashboard(title, timers);
        await DiscordMessages.Modify(channel, mvpDashboardMessage.MessageId, discordMessage);

        mvpDashboardRepository.UpdateDashboardMessageMvpIds(page, timers.Select(t => t.Timer.Id));

        logger.LogInformation($"Mvp Dashboard '{title}' updated.");
    }

    private bool IsSameList(HashSet<string> hashSet1, HashSet<string> hashSet2)
    {
        return hashSet1.Count == hashSet2.Count && hashSet1.All(hashSet2.Contains);
    }
}