using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RagnaBot.Data;
using RagnaBot.Modules;
using RagnaBot.Origin;
using RagnaBot.Services;

namespace RagnaBot
{
    internal static class Program
    {
        private static async Task Main()
        {
            using var cts = new CancellationTokenSource();

            var serviceProvider = RegisterServices();
            var repository = serviceProvider.GetService<Repository>()!;
            var discordClient = serviceProvider.GetService<DiscordClient>()!;
            var mvpModule = serviceProvider.GetService<MvpModule>()!;
            var marketModule = serviceProvider.GetService<MarketModule>()!;

            await repository.Load();
            await discordClient.ConnectAsync();

            await Task.WhenAny(
                mvpModule.Start(cts.Token),
                marketModule.Start(cts.Token),
                repository.StartSaveWatcher(cts.Token)
            );
        }

        private static IServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();

            // Config
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .Get<Config>();
            services.AddSingleton(config);

            // Data
            services.AddSingleton<Repository>();

            // MVP Services
            services.AddSingleton<MvpTimerService>();
            services.AddSingleton<MessageCleanupService>();
            services.AddSingleton<MvpDashboardService>();
            services.AddSingleton<MvpModule>();

            // Market Services
            services.AddHttpClient<OriginClient>();
            services.AddSingleton<OriginClient>();
            services.AddSingleton<MarketWatcherService>();
            services.AddSingleton<MarketCollectorService>();
            services.AddSingleton<MarketModule>();

            // Discord
            services.AddSingleton(
                sp => new DiscordClient(
                    new DiscordConfiguration
                    {
                        Token = sp.GetService<Config>()!.DiscordBotToken,
                        TokenType = TokenType.Bot,
                        MinimumLogLevel = LogLevel.Information
                    }
                )
            );
            services.AddSingleton<ILogger>(sp => sp.GetService<DiscordClient>()!.Logger);
            var serviceProvider = services.BuildServiceProvider();

            // Configure Discord
            var discordClient = serviceProvider.GetService<DiscordClient>()!;
            var commands = discordClient.UseCommandsNext(
                new CommandsNextConfiguration
                {
                    Services = serviceProvider,
                    StringPrefixes = config.CommandPrefix
                }
            );
            commands.RegisterCommands<MvpModule>();
            commands.RegisterCommands<MarketModule>();

            return serviceProvider;
        }
    }
}