using System.Runtime.Serialization;

namespace BankOfSuccess.BusinessLogic
{
    [Serializable]
    internal class InvalidPINException : Exception
    {
        public InvalidPINException()
        {
        }

        public InvalidPINException(string? message) : base(message)
        {
        }

        public InvalidPINException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidPINException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}