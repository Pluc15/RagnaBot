using System;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using Microsoft.Extensions.Logging;

[CommandContextType(InteractionContextType.PrivateChannel, InteractionContextType.Guild)]
[IntegrationType(ApplicationIntegrationType.GuildInstall)]
[Group("vendor", "Get alerts for specific vendors")]
public class VendorModule(
        AddVendorWatcherAction addVendorWatcherAction,
        DeleteVendorWatcherAction deleteVendorWatcherAction,
        GetVendorWatchersForUserAction getVendorWatchersForUserAction,
        ILogger<VendorModule> logger
) : BaseModule
{
    [SlashCommand("add", "Start watching a vendor")]
    public async Task Add(string vendorName)
    {
        try
        {
            var watcher = addVendorWatcherAction.Run(Context.User, vendorName);

            await RespondAsync(DiscordMessages.VendorWatcherAdded(watcher));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await RespondAsync(DiscordMessages.UnexpectedError(ex));
        }
    }

    [SlashCommand("remove", "Stop watching a vendor")]
    public async Task Remove(string vendorName)
    {
        try
        {
            deleteVendorWatcherAction.Run(Context.User, vendorName);

            await RespondAsync(DiscordMessages.VendorWatcherRemoved(vendorName));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await RespondAsync(DiscordMessages.UnexpectedError(ex));
        }
    }

    [SlashCommand("list", "List your watched vendors")]
    public async Task List()
    {
        try
        {
            var watchers = getVendorWatchersForUserAction.Run(Context.User);

            await RespondAsync(DiscordMessages.VendorWatcherList(watchers));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await RespondAsync(DiscordMessages.UnexpectedError(ex));
        }
    }
}
