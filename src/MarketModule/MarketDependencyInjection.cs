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
        builder.Services.AddSingleton<VendorWatcherRepository>();

        // Actions
        builder.Services.AddSingleton<AddWatcherAction>();
        builder.Services.AddSingleton<DeleteWatcherAction>();
        builder.Services.AddSingleton<EvaluateMarketWatchersAction>();
        builder.Services.AddSingleton<GetWatchersForUserAction>();
        builder.Services.AddSingleton<UpdateMarketAction>();
        builder.Services.AddSingleton<AddVendorWatcherAction>();
        builder.Services.AddSingleton<DeleteVendorWatcherAction>();
        builder.Services.AddSingleton<GetVendorWatchersForUserAction>();
        builder.Services.AddSingleton<EvaluateVendorWatchersAction>();

        // Modules
        builder.Services.AddSingleton<MarketModule>();
        builder.Services.AddSingleton<VendorModule>();

        // Jobs
        builder.Services.AddSingleton<MarketDataJob>();

        return builder;
    }
}