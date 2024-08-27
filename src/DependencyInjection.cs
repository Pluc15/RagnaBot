using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Discord.Interactions;
using Discord.WebSocket;
using Discord;

public static class DependencyInjection
{
    public static HostApplicationBuilder RegisterServices(this HostApplicationBuilder builder)
    {
        // Config
        builder.Services.Configure<Config>(builder.Configuration);

        // Add a generic service provider
        builder.Services.AddSingleton(sp => sp);

        // Databases
        builder.Services.AddSingleton<Database>();
        builder.Services.AddSingleton<ItemInfoDatabase>();
        builder.Services.AddSingleton<MarketDatabase>();
        builder.Services.AddSingleton<MvpInfoDatabase>();

        // Repositories
        builder.Services.AddSingleton<ItemInfoRepository>();
        builder.Services.AddSingleton<MarketListingRepository>();
        builder.Services.AddSingleton<MarketWatcherRepository>();
        builder.Services.AddSingleton<MvpDashboardRepository>();
        builder.Services.AddSingleton<MvpInfoRepository>();
        builder.Services.AddSingleton<MvpMessagesCleanupRepository>();
        builder.Services.AddSingleton<MvpTimersRepository>();

        // Actions
        builder.Services.AddSingleton<AddWatcherAction>();
        builder.Services.AddSingleton<CleanupMvpMessagesAction>();
        builder.Services.AddSingleton<DeleteOldMvpTimersAction>();
        builder.Services.AddSingleton<DeleteWatcherAction>();
        builder.Services.AddSingleton<EvaluateMarketWatchersAction>();
        builder.Services.AddSingleton<GetWatchersForUserAction>();
        builder.Services.AddSingleton<QueueMessageForCleanupAction>();
        builder.Services.AddSingleton<RegisterMvpTimeOfDeathAction>();
        builder.Services.AddSingleton<SendMvpTimerRemindersAction>();
        builder.Services.AddSingleton<UpdateMarketAction>();
        builder.Services.AddSingleton<UpdateMvpDashboardAction>();

        // Modules
        builder.Services.AddSingleton<MarketModule>();
        builder.Services.AddSingleton<MvpModule>();

        // Workers
        builder.Services.AddHostedService<Worker>();

        // Arcadia Client
        builder.Services.AddHttpClient<ArcadiaClient>();

        // Discord Client
        builder.Services.AddSingleton(new DiscordSocketConfig
        {
            GatewayIntents = GatewayIntents.Guilds
        });
        builder.Services.AddSingleton(new InteractionServiceConfig());
        builder.Services.AddSingleton<DiscordSocketClient>();
        builder.Services.AddSingleton(sp => new InteractionService(sp.GetService<DiscordSocketClient>()));
        builder.Services.AddSingleton<DiscordConnection>();

        return builder;
    }
}