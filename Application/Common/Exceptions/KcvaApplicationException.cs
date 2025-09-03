using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    public sealed class KcvaApplicationException : Exception
    {
        public KcvaApplicationException() : base()
        { }

        public KcvaApplicationException(string? message) : base(message)
        {
        }

        public KcvaApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

        public KcvaApplicationException(string? message, Exception? innerException) : base(message, innerException)
        {

        }
    }
}
