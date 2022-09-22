using BankOfSuccess.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Entities
{
    internal class AllAccountsRepo
    {
        //List of All Account...........
        public static List<Account> allAccounts = new List<Account>();
        public static void AddToLog(Account account)
        {
            AllAccountsRepo.allAccounts.Add(account);
        }
        //to get account details by account no
        public static Account getAccount(int accNo)
        {
            Account account = null;
            foreach (Account acc in AllAccountsRepo.allAccounts)
            {
                if (acc.AccountNo == accNo)
                {
                    account = acc;
                }
            }
            if (account == null)
            {
                throw new AccountNotFoundException("Account Not Found !!!");
            }
            return account;
        }

    }
}