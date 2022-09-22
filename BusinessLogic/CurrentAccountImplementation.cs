using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfSuccess.BusinessLogic;
using BankOfSuccess.Entities;

namespace BankOfSuccess.BusinessLogic
{
    //this current account implentation class is implementing accimplementation interface and it will have to define open account methos for the current account only
    internal class CurrentAccountImplementation : AccountImplementation
    {
        // Check that the user details is valid or not like Registration and account is active ......... 
        public bool OpenAccount(Account accountTobeOpened)
        {
            bool isAccountOpened = false;
            //upcasting is here 
            CurrentAccount account = (CurrentAccount)accountTobeOpened;
            if (account.IsActive == true)
            {
                throw new CurrentAccAlreadyOpenException("Current Account is Already opened !!!");
            }
            if (IsRegNoValid(account.RegistrationNo))
            {
                account.IsActive = true;
                isAccountOpened = true;
                AllAccountsRepo.AddToLog(account);
                // AllAccountsRepo.allAccounts.Add(account); // adding current account in account repository
            }
            else
            {
                throw new InvalidRegNoException("Inavalid Registration Number !!!");
            }
            return isAccountOpened;
        }

        private bool IsRegNoValid(string regNo)
        {
            if (regNo == null)
            {
                throw new InvalidRegNoException("Invalid Registration Number !!!");
            }
            else return true;
        }

    }
}
