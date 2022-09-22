using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.BusinessLogic
{
    internal class Notification
    {
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public double Amount { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool SMSActive { get; set; }
        public bool EmailActive { get; set; }

        public Notification(int accountNumber, string name, double balance, double amount, string phoneNumber, string email, bool isActive, bool smsActive, bool emailActive)
        {
            AccountNumber = accountNumber;
            Name = name;
            Balance = balance;
            Amount = amount;
            PhoneNumber = phoneNumber;
            Email = email;
            IsActive = isActive;
            SMSActive = smsActive;
            EmailActive = emailActive;
        }
        public Notification() { }
    }

}
