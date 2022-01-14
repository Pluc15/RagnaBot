using System;

namespace RagnaBot.Exceptions
{
    public class InvalidCommandArgumentsException : Exception
    {
        public InvalidCommandArgumentsException(
            string message
        ) : base(message)
        {
        }
    }
}