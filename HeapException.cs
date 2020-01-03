using System;
using System.Runtime.Serialization;

namespace EugeneOlsen
{
    [Serializable]
    internal class HeapException : Exception
    {
        public HeapException()
        {
        }

        public HeapException(string message) : base(message)
        {
        }

        public HeapException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HeapException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}