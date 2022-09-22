using BankOfSuccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfSuccess.Entities;

namespace BankOfSuccess
{
    internal class TransactionLog
    {
        //list of all transactions
        private static List<Transaction> Transactions = new List<Transaction>();
       //adding each transaction to the above list
        public static void AddToLog(Transaction transaction)
        {
            Transactions.Add(transaction);
        }
        //to get transaction details of a perticular account
        public static List<Transaction> GetTransfersFromLog(Account fromAccount)
        {
            List<Transaction> transactions = new List<Transaction>();

            foreach (Transaction t in Transactions)
            {
                if (fromAccount.AccountNo == fromAccount.AccountNo)
                {
                    transactions.Add(t);
                }
            }
            return transactions;
        }
        //to get all the transactions
        public static List<Transaction> GetAllTransfersFromLog()
        {
            return Transactions;
        }

    }
}