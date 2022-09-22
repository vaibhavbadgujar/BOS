using System;
using BankOfSuccess.Entities;

namespace BankOfSuccess.BusinessLogic
{
    public class TransferLog
    {
        // List of All Transfers DOne.........
        private static List<FundTransfer> transferLog = new List<FundTransfer>();
        public static void addTransferDetails(FundTransfer transfer)
        {
            transferLog.Add(transfer);
        }

        // Gives the list of transfers done by perticular account ..........
        public List<FundTransfer> GetTransfers(Account senderAccNo)
        {
            List<FundTransfer> returnTransfers = new List<FundTransfer>();
            foreach (FundTransfer transfer in transferLog)
            {
                if (transfer.sender.AccountNo == senderAccNo.AccountNo)
                {
                    returnTransfers.Add(transfer);
                }
            }
            return returnTransfers;

        }
    }
}

