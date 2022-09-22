using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfSuccess.Entities;

namespace BankOfSuccess.BusinessLogic
{
    //this saving account implentation class is implementing accimplementation interface and it will have to define open account methos for the saving account only
    internal class SavingAccountImplementation : AccountImplementation
    {
        // Check that the user details is valid or not like Age and account is active ......... 
        public bool OpenAccount(Account accountTobeOpened)
        {
            bool result = false;
            SavingAccount account =accountTobeOpened as SavingAccount;
            if (account.IsActive == true)
            {
                throw new AccountIsAlreadyCreated("Account is Already Opened !!!");
            }
            if (IsAgeValid(account.DOB))
            {
                account.IsActive = true;
                // Console.WriteLine("savings acc can be opened age is valid");
                result = true;
               AllAccountsRepo.AddToLog(account);
               // AllAccountsRepo.allAccounts.Add(account); // adding Saving account in account repository
            }
            else
            {
                throw new InvalidAgeException("Invalid Age !!!");
            }
            return result;
        }

        // Age calculator...........
        private bool IsAgeValid(DateTime dob)
        {
            if (int.Parse(DateTime.Now.Year.ToString()) - int.Parse(dob.Year.ToString()) < 18)
            {
                throw new InvalidAgeException("Invalid Age !!!");
            }
            else return true;
        }
    }
}
