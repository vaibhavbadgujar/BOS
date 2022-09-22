using BankOfSuccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Entities
{
    internal class Transaction
    {
        [Key] 
        public int TransactionID { get; set; }
        public string TransactionType { get; set; }   //deposit  withdraw  transfer only
        public Account SenderAccount { get; set; }
        public Account ReceiverAccount { get; set; }
        public double Amount { get; set; }
        [NotMapped]
        public TransferMode Mode { get; set; }
        public DateTime TansactionDate { get; set; }
        


        public Transaction(Account senderAccount, Account receiverAccount, double amount, TransferMode mode, DateTime tansactionDate, string transactionType)
        {
            TransactionType = transactionType;
            SenderAccount = senderAccount;
            ReceiverAccount = receiverAccount;
            Amount = amount;
            Mode = mode;
            TansactionDate = tansactionDate;
        }
        
        public Transaction() { }
    }
}
