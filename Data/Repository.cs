using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using RagnaBot.Models;

namespace RagnaBot.Data
{
    public partial class Repository
    {
        private readonly Config _config;
        private readonly ILogger _logger;
        private DatabaseModel _data;
        private bool _dirty;

        private readonly Policy _saveRetryPolicy = Policy
            .Handle<Exception>()
            .WaitAndRetryForever(i => TimeSpan.FromSeconds(1));

        private static readonly JsonSerializerSettings JsonSerializerSettings = new()
        {
            NullValueHandling = NullValueHandling.Include
        };

        public Repository(
            Config config,
            ILogger logger
        )
        {
            _config = config;
            _logger = logger;
        }

        public async Task Load()
        {
            if (File.Exists(_config.SaveFile))
            {
                var loadData = await File.ReadAllTextAsync(_config.SaveFile);
                _data = JsonConvert.DeserializeObject<DatabaseModel>(loadData);
            }
            else
            {
                _data = new DatabaseModel();
            }
        }

        public async Task StartSaveWatcher(
            CancellationToken ct
        )
        {
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
                    var data = JsonConvert.SerializeObject(_data, Formatting.Indented, JsonSerializerSettings);
                    await File.WriteAllTextAsync(_config.SaveFile, data);
                }
            );
            _logger.LogInformation("Data saved");
        }
    }
}