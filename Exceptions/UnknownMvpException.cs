using System;

namespace RagnaBot.Exceptions
{
    public class UnknownMvpException : Exception
    {
        public UnknownMvpException() : base("Unknown MvP")
        {
        }
    }
}