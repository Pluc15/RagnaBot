using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RagnaBot.Data
{
    public class Repository
    {
        private readonly Config _config;
        private Model _data;

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
                var data = await File.ReadAllTextAsync(_config.SaveFile);
                _data = JsonConvert.DeserializeObject<Model>(data);
            }
            else
            {
                _data = new Model();
                Seed.Init(_data);
            }
        }

        public Task SaveAsync()
        {
            return File.WriteAllTextAsync(_config.SaveFile, JsonConvert.SerializeObject(_data, Formatting.Indented));
        }

        public Timer GetTimer(
            string mvpKey
        )
        {
            return _data.Timers.SingleOrDefault(t => t.MvpKeys.Any(k => k == mvpKey));
        }

        public IEnumerable<Timer> GetTimers()
        {
            return _data.Timers.ToList();
        }

        public void AddMessageToCleanup(
            ulong id,
            DateTime deletionTime
        )
        {
            _data.MessagesToCleanup.Add(
                new MessageReference
                {
                    Id = id,
                    DeletionTime = deletionTime
                }
            );
        }

        public IEnumerable<MessageReference> GetMessageToCleanups()
        {
            return _data.MessagesToCleanup.Where(m => m.DeletionTime < DateTime.UtcNow).ToList();
        }

        public void RemoveMessageToCleanup(
            MessageReference messageReference
        )
        {
            _data.MessagesToCleanup.Remove(messageReference);
        }

        public bool HasDashboardMessageId(
            int page
        )
        {
            return _data.DashboardMessageIds.ContainsKey(page);
        }

        public ulong GetDashboardMessageId(
            int page
        )
        {
            return _data.DashboardMessageIds[page];
        }

        public void UpdateDashboardMessageId(
            int page,
            ulong messageId
        )
        {
            _data.DashboardMessageIds[page] = messageId;
        }
    }
}