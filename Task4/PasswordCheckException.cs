using System;
using System.Runtime.Serialization;

namespace Task4
{
    [Serializable]
    internal class PasswordCheckException : ApplicationException
    {
        public PasswordCheckException()
        {
        }

        public PasswordCheckException(string message) : base(message)
        {
        }

        public PasswordCheckException(string message, Exception innerException) : 
            base(message, innerException)
        {
        }

        protected PasswordCheckException(SerializationInfo info, StreamingContext context) : 
            base(info, context)
        {
        }
    }
}