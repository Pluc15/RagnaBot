using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Discord.Interactions;
using Discord.WebSocket;
using Discord;
using Microsoft.Extensions.Logging;

public static class DependencyInjection
{
    public static HostApplicationBuilder RegisterServices(this HostApplicationBuilder builder)
    {
        // Config
        builder.Services
            .AddOptions<Config>()
            .Bind(builder.Configuration)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        // Monitoring
        builder.Services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddSimpleConsole(options =>
            {
                options.IncludeScopes = false;
                options.SingleLine = true;
                options.TimestampFormat = "HH:mm:ss ";
            });
        });

        // Add a generic service provider
        builder.Services.AddSingleton(sp => sp);

        // Databases
        builder.Services.AddSingleton<Database>();
        builder.Services.AddSingleton<ItemInfoDatabase>();
        builder.Services.AddSingleton<MarketDatabase>();
        builder.Services.AddSingleton<MvpInfoDatabase>();

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

        // Modules
        builder.RegisterMvpServices();
        builder.RegisterMarketServices();
        builder.Services.AddSingleton<TimeTagModule>();

        // Workers
        builder.Services.AddHostedService<Worker>();

        return builder;
    }
}