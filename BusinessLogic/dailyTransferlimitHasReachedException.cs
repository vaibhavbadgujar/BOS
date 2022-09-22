using System.Runtime.Serialization;

namespace BankOfSuccess.BusinessLogic
{
    [Serializable]
    internal class dailyTransferlimitHasReachedException : Exception
    {
        public dailyTransferlimitHasReachedException()
        {
        }

        public dailyTransferlimitHasReachedException(string? message) : base(message)
        {
        }

        public dailyTransferlimitHasReachedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected dailyTransferlimitHasReachedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}