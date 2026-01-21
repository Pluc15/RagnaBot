using System;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

// TODO Split this into module specific
public class DiscordConnection(
    IOptions<Config> config,
    IServiceProvider servicesProvider,
    InteractionService interactionService,
    DiscordSocketClient discordClient,
    ILogger<DiscordConnection> logger
)
{
    public async Task Init()
    {
        await interactionService.AddModuleAsync<MvpModule>(servicesProvider);
        await interactionService.AddModuleAsync<MarketModule>(servicesProvider);
        await interactionService.AddModuleAsync<VendorModule>(servicesProvider);
        await interactionService.AddModuleAsync<TimeTagModule>(servicesProvider);

        discordClient.InteractionCreated += DiscordInteractionCreated;
        discordClient.Ready += DiscordReady;
        discordClient.GuildAvailable += DiscordGuildAvailable;
        discordClient.JoinedGuild += DiscordJoinedGuild;
        discordClient.Log += DiscordLog;

        await discordClient.LoginAsync(TokenType.Bot, config.Value.DiscordBotToken);
        await discordClient.StartAsync();
    }

    private Task DiscordGuildAvailable(SocketGuild guild)
    {
        logger.LogInformation($"DiscordSocketClient.GuildAvailable '{guild.Name}'");
        return Task.CompletedTask;
    }

    private Task DiscordJoinedGuild(SocketGuild guild)
    {
        logger.LogInformation($"DiscordSocketClient.JoinedGuild '{guild.Name}'");
        return Task.CompletedTask;
    }

    private async Task DiscordReady()
    {
        foreach (var guild in discordClient.Guilds)
            await RegisterCommandsToGuild(guild!);
    }

    private async Task RegisterCommandsToGuild(SocketGuild guild)
    {
        var commands = await interactionService.RegisterCommandsToGuildAsync(guild.Id);
        foreach (var command in commands)
            logger.LogInformation($"Registered command '{command.Name}' in guild '{guild.Name}'.");
    }

    private async Task DiscordInteractionCreated(SocketInteraction interaction)
    {
        var context = new SocketInteractionContext(discordClient, interaction);
        await interactionService.ExecuteCommandAsync(context, servicesProvider);
    }

    private Task DiscordLog(LogMessage message)
    {
        var logLevel = message.Severity switch
        {
            LogSeverity.Critical => LogLevel.Critical,
            LogSeverity.Error => LogLevel.Error,
            LogSeverity.Warning => LogLevel.Warning,
            LogSeverity.Info => LogLevel.Information,
            LogSeverity.Verbose => LogLevel.Debug,
            LogSeverity.Debug => LogLevel.Debug,
            _ => throw new NotImplementedException(),
        };

        logger.Log(logLevel, message.Exception, $"{message.Source}: {message.Message}");

        return Task.CompletedTask;
    }
}