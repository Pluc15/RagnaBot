using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;

public class MvpDatabase(
    IOptions<Config> config,
    ILogger<MvpDatabase> logger)
{
    private MvpDatabaseModel? _data;

    public bool Dirty { get; set; }

    public MvpDatabaseModel Data => _data ?? throw new Exception("Data not loaded.");

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
        if (File.Exists(config.Value.SaveFile))
        {
            var loadData = await File.ReadAllTextAsync(config.Value.SaveFile);
            _data = JsonSerializer.Deserialize<MvpDatabaseModel>(loadData) ?? throw new Exception("Failed to deserialize the save file.");
            logger.LogInformation("Loaded database.");
        }
        else
        {
            _data = new MvpDatabaseModel();
            logger.LogInformation("No database, created a fresh one.");
        }
    }

    public async Task StartSaveWatcher(
        CancellationToken ct
    )
    {
        logger.LogInformation("Starting the data watcher.");
        while (!ct.IsCancellationRequested)
        {
            if (Dirty)
            {
                Dirty = false;
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
                await File.WriteAllTextAsync(config.Value.SaveFile, data);
            }
        );
        logger.LogInformation("Data saved");
    }
}