using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.Entities
{
    internal class CurrentAccount : Account
    {
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public string RegistrationNo { get; set; }

        //constructor.........
        public CurrentAccount(string companyName, string website, string registration, string name, string phoneNo, string email, int pin, DateTime activationdate, bool activateSMS, bool activateEmail) : base(name,phoneNo,email, pin, activationdate ,activateSMS,activateEmail)
        {
            CompanyName = companyName;
            Website = website;
            RegistrationNo = registration;
        }

    }

}
