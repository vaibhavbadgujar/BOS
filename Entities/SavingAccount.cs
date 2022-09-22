using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Entities
{
    internal class SavingAccount : Account
    {
        public DateTime DOB { get; set; }
        public Char Gender { get; set; }
       // public string PhoneNo { get; set; }

        //constructor..............
        public SavingAccount(DateTime dOB, char gender, string name, string phoneNo, string email, int pin, DateTime activationdate, bool activateSMS, bool activateEmail) : base(name,phoneNo,email, pin, activationdate,activateSMS,activateEmail)
        {

            DOB = dOB;
            Gender = gender;

           // PhoneNo = phoneNo;
        }
        public SavingAccount()
        {

        }
    }
}
