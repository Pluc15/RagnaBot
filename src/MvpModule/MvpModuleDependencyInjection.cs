using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class MvpModuleDependencyInjection
{
    public static HostApplicationBuilder RegisterMvpServices(this HostApplicationBuilder builder)
    {
        // Repositories
        builder.Services.AddSingleton<MvpConfigRepository>();
        builder.Services.AddSingleton<MvpDashboardRepository>();
        builder.Services.AddSingleton<MvpInfoRepository>();
        builder.Services.AddSingleton<MvpMessagesCleanupRepository>();
        builder.Services.AddSingleton<MvpTimersRepository>();

        // Actions
        builder.Services.AddSingleton<CleanupMvpMessagesAction>();
        builder.Services.AddSingleton<DeleteOldMvpTimersAction>();
        builder.Services.AddSingleton<QueueMvpMessageForCleanupAction>();
        builder.Services.AddSingleton<RegisterMvpTimeOfDeathAction>();
        builder.Services.AddSingleton<SendMvpTimerRemindersAction>();
        builder.Services.AddSingleton<UpdateMvpDashboardAction>();
        builder.Services.AddSingleton<UpdateMvpConfigurationAction>();

        // Modules
        builder.Services.AddSingleton<MvpModule>();

        return builder;
    }
}