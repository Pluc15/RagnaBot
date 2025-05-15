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

        // Modules
        builder.RegisterMvpServices();
        builder.RegisterMarketServices();
        builder.Services.AddSingleton<TimeTagModule>();

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