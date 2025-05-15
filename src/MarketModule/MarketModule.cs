using System;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

[CommandContextType(InteractionContextType.PrivateChannel, InteractionContextType.Guild)]
[IntegrationType(ApplicationIntegrationType.GuildInstall)]
[Group("market", "Market watcher")]
public class MarketModule(
        IOptions<Config> config,
        AddWatcherAction addWatcherAction,
        DeleteWatcherAction deleteWatcherAction,
        GetWatchersForUserAction getWatchersForUserAction,
        UpdateMarketAction updateMarketAction,
        EvaluateMarketWatchersAction evaluateMarketWatchersAction,
        ILogger<MarketModule> logger
    ) : BaseModule
{
    public async Task Start(
        CancellationToken ct
    )
    {
        logger.LogInformation("Starting the MarketModule");
        while (!ct.IsCancellationRequested)
        {
            try
            {
                await updateMarketAction.Run();
                await evaluateMarketWatchersAction.Run();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
            await Task.Delay(TimeSpan.FromMinutes(11), ct);
        }
    }

    [SlashCommand("add", "Add a watched item")]
    public async Task Watch(int itemId, int maximumPrice)
    {
        if (Context.Channel.Id != config.Value.MarketTrackerChannelId)
            return;

        try
        {
            // Process
            var (itemInfo, watcher) = addWatcherAction.Run(Context.User, itemId, maximumPrice);

            // Respond
            await RespondAsync(DiscordMessages.MarketWatcherCreated(itemInfo, watcher));
        }
        catch (ItemInfoNotFoundException ex)
        {
            logger.LogWarning(ex, ex.Message);
            await RespondAsync(DiscordMessages.ItemInfoNotFound(ex));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await RespondAsync(DiscordMessages.UnexpectedError(ex));
        }
    }

    [SlashCommand("remove", "Stop watching an item")]
    public async Task Unwatch(int itemId)
    {
        if (Context.Channel.Id != config.Value.MarketTrackerChannelId)
            return;

        try
        {
            // Process
            var item = deleteWatcherAction.Run(Context.User, itemId);

            // Respond
            await RespondAsync(DiscordMessages.MarketWatcherDeleted(item));
        }
        catch (MarketWatcherNotFoundException ex)
        {
            logger.LogWarning(ex, ex.Message);
            await RespondAsync(DiscordMessages.MarketWatcherNotFound(ex));
        }
        catch (ItemInfoNotFoundException ex)
        {
            logger.LogWarning(ex, ex.Message);
            await RespondAsync(DiscordMessages.ItemInfoNotFound(ex));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await RespondAsync(DiscordMessages.UnexpectedError(ex));
        }
    }

    [SlashCommand("list", "List your watched items")]
    public async Task Watchlist()
    {
        if (Context.Channel.Id != config.Value.MarketTrackerChannelId)
            return;

        try
        {
            var watchers = getWatchersForUserAction.Run(Context.User);
            await RespondAsync(DiscordMessages.MarketWatcherList(watchers));
        }
        catch (ItemInfoNotFoundException ex)
        {
            logger.LogWarning(ex, ex.Message);
            await RespondAsync(DiscordMessages.ItemInfoNotFound(ex));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await RespondAsync(DiscordMessages.UnexpectedError(ex));
        }
    }
}
