using System;
using System.Runtime.Serialization;

namespace Iconnect.Infraestrutura.Exceptions
{
    [Serializable]
    public class MensagemException : Exception
    {
        public MensagemException()
        { }

        public MensagemException(string message) : base(message)
        { }

        public MensagemException(string message, Exception innerException) : base(message, innerException)
        { }

        protected MensagemException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}