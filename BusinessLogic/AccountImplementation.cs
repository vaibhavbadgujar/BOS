using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfSuccess.Entities;

namespace BankOfSuccess.BusinessLogic
{
    // Interface for open account ............
    internal interface AccountImplementation
    {
        //interface having method to create an account
        public bool OpenAccount(Account accountTobeOpened);
        
    }
}
