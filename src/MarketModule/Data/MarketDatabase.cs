using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;

public class MarketDatabase(
    IOptions<Config> config,
    ILogger<MarketDatabase> logger)
{
    private Market? _data;

    private bool _dirty = false;

    public Market Data
    {
        get => _data ?? throw new Exception("Market data not loaded.");
        set
        {
            _data = value;
            _dirty = true;
        }
    }

    private readonly Policy _saveRetryPolicy = Policy
        .Handle<Exception>()
        .WaitAndRetryForever(i => TimeSpan.FromSeconds(1));

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = true
    };

    public async Task Load()
    {
        if (File.Exists(config.Value.MarketSaveFile))
        {
            var loadData = await File.ReadAllTextAsync(config.Value.MarketSaveFile);
            _data = JsonSerializer.Deserialize<Market>(loadData) ?? throw new Exception("Failed to deserialize the market save file.");
            logger.LogInformation("Loaded market database.");
        }
        else
        {
            _data = new Market { Shops = [] };
            logger.LogInformation("No market database, created a fresh one.");
        }
    }

    public async Task StartSaveWatcher(
        CancellationToken ct
    )
    {
        logger.LogInformation("Starting the market data watcher.");
        while (!ct.IsCancellationRequested)
        {
            if (_dirty)
            {
                _dirty = false;
                await Save();
            }

            await Task.Delay(5000, ct);
        }
    }

    private async Task Save()
    {
        await _saveRetryPolicy.Execute(
            async () =>
            {
                var data = JsonSerializer.Serialize(_data, JsonSerializerOptions);
                await File.WriteAllTextAsync(config.Value.MarketSaveFile, data);
            }
        );
        logger.LogInformation("Market Data saved");
    }
}
