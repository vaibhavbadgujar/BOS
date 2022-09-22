using System.Runtime.Serialization;

namespace BankOfSuccess.BusinessLogic
{
    [Serializable]
    internal class CurrentAccAlreadyOpenException : Exception
    {
        public CurrentAccAlreadyOpenException()
        {
        }

        public CurrentAccAlreadyOpenException(string? message) : base(message)
        {
        }

        public CurrentAccAlreadyOpenException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CurrentAccAlreadyOpenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}