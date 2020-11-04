using System;
using System.Runtime.Serialization;

namespace Task2
{
    [Serializable]
    internal class ArrayToolsException : ApplicationException
    {
        public ArrayToolsException()
        {
        }

        public ArrayToolsException(string message) : base(message)
        {
        }

        public ArrayToolsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ArrayToolsException(SerializationInfo info, 
            StreamingContext context) : base(info, context)
        {
        }
    }
}