using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RagnaBot.Models;

namespace RagnaBot.Data
{
    public partial class Repository : IDisposable
    {
        private readonly Config _config;
        private DatabaseModel _data;
        private FileStream _fileStream;

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
                _data = JsonConvert.DeserializeObject<DatabaseModel>(sb.ToString());
            }
            else
            {
                _data = new DatabaseModel();
                await SaveAsync();
            }
        }

        public Task SaveAsync()
        {
            var data = JsonConvert.SerializeObject(_data, Formatting.Indented, JsonSerializerSettings);
            var bytes = Encoding.UTF8.GetBytes(data);

            _fileStream.SetLength(0);
            _fileStream.Position = 0;
            return _fileStream.WriteAsync(bytes, 0, bytes.Length);
        }

        public void Dispose()
        {
            _fileStream?.Dispose();
        }
    }
}