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
            await serviceProvider.GetService<Repository>()!.Load();
            serviceProvider.GetService<MessageCleanupService>()!.RegisterAutoCleanup();
            await serviceProvider.GetService<DiscordClient>()!.ConnectAsync();
            await serviceProvider.GetService<MvpDashboardService>()!.Init();
            await serviceProvider.GetService<MvpDashboardService>()!.Update();
            while (!cts.IsCancellationRequested)
            {
                await SendReminders(serviceProvider);
                await DeleteOldTimers(serviceProvider);
                await CleanupMessages(serviceProvider);
                await Task.Delay(1000, cts.Token);
            }
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

        private static async Task SendReminders(
            IServiceProvider serviceProvider
        )
        {
            try
            {
                await serviceProvider.GetService<MvpTimerService>()!.SendReminders();
            }
            catch (Exception ex)
            {
                serviceProvider.GetService<ILogger>()!.LogError(ex, "Unhandled error");
            }
        }

        private static async Task DeleteOldTimers(
            IServiceProvider serviceProvider
        )
        {
            try
            {
                await serviceProvider.GetService<MvpTimerService>()!.DeleteOldTimers();
            }
            catch (Exception ex)
            {
                serviceProvider.GetService<ILogger>()!.LogError(ex, "Unhandled error");
            }
        }

        private static async Task CleanupMessages(
            IServiceProvider serviceProvider
        )
        {
            try
            {
                await serviceProvider.GetService<MessageCleanupService>()!.Cleanup();
            }
            catch (Exception ex)
            {
                serviceProvider.GetService<ILogger>()!.LogError(ex, "Unhandled error");
            }
        }
    }
}