using System;
using System.Collections.Generic;
using System.Linq;
using RagnaBot.Models;

namespace RagnaBot.Data
{
    public partial class Repository
    {
        public void AddMessageToCleanup(
            ulong id,
            DateTime deletionTime,
            string mvpId
        )
        {
            _data.MessagesToCleanup.Add(
                new MessageReference
                {
                    Id = id,
                    DeletionTime = deletionTime,
                    MvpId = mvpId
                }
            );
            _dirty = true;
        }

        public IEnumerable<MessageReference> GetMessagesToCleanupExpired()
        {
            return _data.MessagesToCleanup
                .Where(m => m.DeletionTime < DateTime.UtcNow)
                .ToList();
        }

        public IEnumerable<MessageReference> GetMessagesToCleanupForMvpId(
            string mvpId
        )
        {
            return _data.MessagesToCleanup
                .Where(m => m.MvpId == mvpId)
                .ToList();
        }

        public void RemoveMessageToCleanup(
            MessageReference messageReference
        )
        {
            _data.MessagesToCleanup.Remove(messageReference);
            _dirty = true;
        }
    }
}