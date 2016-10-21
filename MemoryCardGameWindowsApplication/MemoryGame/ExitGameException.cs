using System;
using System.Runtime.Serialization;

namespace MemoryGame
{
    [Serializable]
    public class ExitGameException : Exception
    {
        public ExitGameException()
        {
        }

        public ExitGameException(string message) : base(message)
        {
        }

        public ExitGameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExitGameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}