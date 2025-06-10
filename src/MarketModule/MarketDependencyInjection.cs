using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class MarketDependencyInjection
{
    public static HostApplicationBuilder RegisterMarketServices(this HostApplicationBuilder builder)
    {
        // Databases
        builder.Services.AddSingleton<ItemInfoDatabase>();
        builder.Services.AddSingleton<MarketDatabase>();

        // Repositories
        builder.Services.AddSingleton<ItemInfoRepository>();
        builder.Services.AddSingleton<MarketListingRepository>();
        builder.Services.AddSingleton<MarketWatcherRepository>();

        // Actions
        builder.Services.AddSingleton<AddWatcherAction>();
        builder.Services.AddSingleton<DeleteWatcherAction>();
        builder.Services.AddSingleton<EvaluateMarketWatchersAction>();
        builder.Services.AddSingleton<GetWatchersForUserAction>();
        builder.Services.AddSingleton<UpdateMarketAction>();

        // Modules
        builder.Services.AddSingleton<MarketModule>();

        return builder;
    }
}