using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class Worker(
    Database database,
    MarketDatabase marketDatabase,
    MarketModule marketModule,
    MvpModule mvpModule,
    DiscordConnection discordConnection,
    ILogger<Worker> logger) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await discordConnection.Init();
        await database.Load();
        await marketDatabase.Load();

        logger.LogInformation("Starting the worker loop.");
        await Task.WhenAny(
            database.StartSaveWatcher(cancellationToken),
            marketDatabase.StartSaveWatcher(cancellationToken),
            // marketModule.Start(cancellationToken),
            mvpModule.Start(cancellationToken)
        );
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
