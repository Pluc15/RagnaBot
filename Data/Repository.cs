using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using RagnaBot.Models;

namespace RagnaBot.Data
{
    public partial class Repository
    {
        private readonly Config _config;
        private DatabaseModel _data;

        private Policy _saveRetryPolicy = Policy
            .Handle<Exception>()
            .RetryForever();

        private static readonly JsonSerializerSettings JsonSerializerSettings = new()
        {
            NullValueHandling = NullValueHandling.Include
        };

        public Repository(
            Config config
        )
        {
            _config = config;
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

        private Task SaveAsync()
        {
            return _saveRetryPolicy.Execute(
                async () =>
                {
                    var data = JsonConvert.SerializeObject(_data, Formatting.Indented, JsonSerializerSettings);
                    await File.WriteAllTextAsync(_config.SaveFile, data);
                }
            );
        }
    }
}