using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RagnaBot.Data
{
    public partial class Repository
    {
        public Task AddMessageToCleanup(
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
            return SaveAsync();
        }

        public IEnumerable<MessageReference> GetMessageToCleanups()
        {
            return _data.MessagesToCleanup
                .Where(m => m.DeletionTime < DateTime.UtcNow)
                .ToList();
        }

        public Task RemoveMessageToCleanup(
            MessageReference messageReference
        )
        {
            _data.MessagesToCleanup.Remove(messageReference);
            return SaveAsync();
        }
    }
}