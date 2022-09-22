using System.Runtime.Serialization;

namespace BankOfSuccess.BusinessLogic
{
    [Serializable]
    internal class InvalidRegNoException : Exception
    {
        public InvalidRegNoException()
        {
        }

        public InvalidRegNoException(string? message) : base(message)
        {
        }

        public InvalidRegNoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidRegNoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}