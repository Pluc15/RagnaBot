using System;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using Microsoft.Extensions.Logging;

[CommandContextType(InteractionContextType.PrivateChannel, InteractionContextType.Guild)]
[IntegrationType(ApplicationIntegrationType.GuildInstall)]
public class MvpModule(
    UpdateMvpConfigurationAction updateMvpConfigurationAction,
        RegisterMvpTimeOfDeathAction registerMvpTimeOfDeathAction,
        UpdateMvpDashboardAction updateMvpDashboardAction,
        CleanupMvpMessagesAction cleanupMvpMessagesAction,
        SendMvpTimerRemindersAction sendMvpTimerRemindersAction,
        DeleteOldMvpTimersAction deleteOldMvpTimersAction,
        ILogger<MvpModule> logger
    ) : BaseModule
{
    public async Task Start(
        CancellationToken ct
    )
    {
        logger.LogInformation("Starting the MvpModule");

        while (!ct.IsCancellationRequested)
        {
            try
            {
                await updateMvpDashboardAction.Run();
                await sendMvpTimerRemindersAction.Run();
                deleteOldMvpTimersAction.Run();
                await cleanupMvpMessagesAction.Run();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
            await Task.Delay(1000, ct);
        }
    }


    [SlashCommand("mvpconfig", "Configure the market watcher")]
    [RequireUserPermission(GuildPermission.Administrator)]
    public async Task Watch(
        [Summary("channel", "The channel to send MVP alerts to")]
        IChannel? channel,
        [Summary("role", "The role to ping in MVP alerts")]
        IRole? role)
    {
        try
        {
            // Process
            updateMvpConfigurationAction.Run(channel, role);

            // Respond
            await RespondAsync(DiscordMessages.MvpConfigurationUpdated());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await RespondAsync(DiscordMessages.UnexpectedError(ex));
        }
    }

    [SlashCommand("mvp", "Report a MvP that has fallen")]
    public async Task Mvp(
        [Autocomplete(typeof(MvpAutocomplete))]
        string mvpKey,
        string timeOfDeath)
    {
        DateTime? dateTimeOfDeath = null;

        try
        {
            // Parse arguments
            mvpKey = mvpKey.Trim().ToLower().Replace(" ", "");
            dateTimeOfDeath = TimeOfDeathParser.Parse(timeOfDeath);

            // Process
            var (timer, mvpInfo) = registerMvpTimeOfDeathAction.Run(mvpKey, dateTimeOfDeath.Value, Context.User);
            await updateMvpDashboardAction.Run();

            // Respond
            await RespondAsync(DiscordMessages.MvpTimerAdded(timer, mvpInfo));
        }
        catch (MvpTimerAlreadyExists ex)
        {
            await RespondAsync(DiscordMessages.MvpTimerAlreadyExists(ex.ExistingMvpTimer, ex.MvpInfo, $"mvp_override_confirm:{mvpKey}:{dateTimeOfDeath?.ToString("HH:mm")}"));
        }
        catch (MvpUnknownException ex)
        {
            logger.LogWarning(ex, ex.Message);
            await RespondAsync(DiscordMessages.MvpUnknown(ex));
        }
        catch (MvpInvalidTimeOfDeathFormatException ex)
        {
            logger.LogWarning(ex, ex.Message);
            await RespondAsync(DiscordMessages.MvpInvalidTimeOfDeathFormat(ex));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await RespondAsync(DiscordMessages.UnexpectedError(ex));
        }
    }

    [ComponentInteraction("mvp_override_confirm:*:*")]
    public async Task MvpOverrideConfirm(
        string mvpKey,
        string timeOfDeath
    )
    {
        try
        {
            // Parse arguments
            mvpKey = mvpKey.Trim().ToLower().Replace(" ", "");
            var dateTimeOfDeath = TimeOfDeathParser.Parse(timeOfDeath);

            // Process
            var (timer, mvpInfo) = registerMvpTimeOfDeathAction.Run(mvpKey, dateTimeOfDeath, Context.User, true);
            await updateMvpDashboardAction.Run();

            // Respond
            await RespondAsync(DiscordMessages.MvpTimerAdded(timer, mvpInfo));
        }
        catch (MvpUnknownException ex)
        {
            logger.LogWarning(ex, ex.Message);
            await RespondAsync(DiscordMessages.MvpUnknown(ex));
        }
        catch (MvpInvalidTimeOfDeathFormatException ex)
        {
            logger.LogWarning(ex, ex.Message);
            await RespondAsync(DiscordMessages.MvpInvalidTimeOfDeathFormat(ex));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await RespondAsync(DiscordMessages.UnexpectedError(ex));
        }
    }
}