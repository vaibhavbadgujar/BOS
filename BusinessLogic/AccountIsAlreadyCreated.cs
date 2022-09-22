using System.Runtime.Serialization;

namespace BankOfSuccess.BusinessLogic
{
    [Serializable]
    internal class AccountIsAlreadyCreated : Exception
    {
        public AccountIsAlreadyCreated()
        {
        }

        public AccountIsAlreadyCreated(string? message) : base(message)
        {
        }

        public AccountIsAlreadyCreated(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AccountIsAlreadyCreated(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}