using System.ComponentModel.DataAnnotations;

namespace BankOfSuccess.Entities
{
    public class Account
    {
        [Key]
        public int accID { get; set; }
        public static int temp = 999;
        
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public int PIN { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public double Balance { get; set; }
        public Privilege Privilge { get; set; }
        public bool IsActive { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public bool ActivateSMS { get; set; }
        public bool ActivateEmail { get; set; }


        //constructor............
        public Account(string name, string phoneNo, string email, int pin, DateTime activationdate, bool activateSMS, bool activateEmail)
        {
            temp++;
            AccountNo = temp;
            Name = name;
            PhoneNo = phoneNo;
            Email = email;
            PIN = pin;
            ActivationDate = activationdate;
            ActivateSMS = activateSMS;
            ActivateEmail = activateEmail;
        }
        public Account(){ }
    }
}