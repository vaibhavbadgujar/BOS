using System.Runtime.Serialization;

namespace BankOfSuccess.BusinessLogic
{
    [Serializable]
    internal class AccountIsAlreadyInactiveException : Exception
    {
        public AccountIsAlreadyInactiveException()
        {
        }

        public AccountIsAlreadyInactiveException(string? message) : base(message)
        {
        }

        public AccountIsAlreadyInactiveException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AccountIsAlreadyInactiveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}