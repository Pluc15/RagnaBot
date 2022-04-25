using System;

namespace RagnaBot.Models
{
    public class MessageReference
    {
        public ulong Id { get; set; }

        public DateTime DeletionTime { get; set; }

        public string MvpId { get; set; }
    }
}