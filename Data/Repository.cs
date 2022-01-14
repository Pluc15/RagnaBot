using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RagnaBot.Data
{
    public class Repository : IDisposable
    {
        private readonly Config _config;
        private Model _data;
        private FileStream _fileStream;

        public Repository(
            Config config
        )
        {
            _config = config;
        }

        public async Task Load()
        {
            if (_fileStream != null)
                throw new InvalidOperationException("Init called twice?");

            var exists = File.Exists(_config.SaveFile);
            _fileStream = File.Open(_config.SaveFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            if (exists)
            {
                var buf = new byte[1024];
                int c;
                var sb = new StringBuilder();
                while ((c = _fileStream.Read(buf, 0, buf.Length)) > 0)
                    sb.Append(Encoding.UTF8.GetString(buf, 0, c));
                _data = JsonConvert.DeserializeObject<Model>(sb.ToString());
            }
            else
            {
                _data = new Model();
                Seed.Init(_data);
                await SaveAsync();
            }
        }

        public Task SaveAsync()
        {
            var data = JsonConvert.SerializeObject(_data, Formatting.Indented);
            var bytes = Encoding.UTF8.GetBytes(data);

            _fileStream.SetLength(0);
            _fileStream.Position = 0;
            return _fileStream.WriteAsync(bytes, 0, bytes.Length);
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

        public void Dispose()
        {
            _fileStream?.Dispose();
        }
    }
}