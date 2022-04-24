using System;
using RagnaBot.Utils;

namespace RagnaBot.Exceptions
{
    public class UnknownMvpException : Exception
    {
        public UnknownMvpException() : base(Messages.UnknownMvp())
        {
        }
    }
}