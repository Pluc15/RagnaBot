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

            await repository.Load();
            await discordClient.ConnectAsync();

            await Task.WhenAny(
                mvpModule.Start(cts.Token),
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

            // Services
            services.AddSingleton<MvpTimerService>();
            services.AddSingleton<MessageCleanupService>();
            services.AddSingleton<MvpDashboardService>();
            services.AddSingleton<MvpModule>();
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

            // Discord
            var discordClient = serviceProvider.GetService<DiscordClient>()!;
            var commands = discordClient.UseCommandsNext(
                new CommandsNextConfiguration
                {
                    Services = serviceProvider,
                    StringPrefixes = config.CommandPrefix
                }
            );
            commands.RegisterCommands<MvpModule>();

            return serviceProvider;
        }
    }
}