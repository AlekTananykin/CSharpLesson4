using System;
using System.Runtime.Serialization;

namespace Task5
{
    [Serializable]
    internal class TwoDimArrayException : Exception
    {
        public TwoDimArrayException()
        {
        }

        public TwoDimArrayException(string message) : base(message)
        {
        }

        public TwoDimArrayException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TwoDimArrayException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}