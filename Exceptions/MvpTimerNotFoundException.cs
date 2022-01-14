using System;
using RagnaBot.Utils;

namespace RagnaBot.Exceptions
{
    public class MvpTimerNotFoundException : Exception
    {
        public MvpTimerNotFoundException() : base(Messages.UnknownMvp())
        {
        }
    }
}