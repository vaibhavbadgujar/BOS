using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfSuccess;
using BankOfSuccess.BusinessLogic;
using BankOfSuccess.Entities;
using BankOfSuccess.Entities;
using BankOfSuccess.BOSDb; 
using BankOfSuccess.BusinessLogic;

namespace BankOfSuccess.UI
{
    // This is the Bank Form which take all detail of user and pass it to the manager to verify ........
    internal class AccountForm
    {
        // create new object of manager.............. 
        AccountManager managerObj = new AccountManager();
        public void OpenAccount()
        {
            Console.WriteLine("What kind of Bank Account you need ?");
            Console.Write("1. Saving Account       \n2. Current Account\n");
            int choice = int.Parse(Console.ReadLine());
            

            // Getting Saving Account detail.............
            if (choice == 1)
            {
                SavingAccount savings = new SavingAccount();
                Console.WriteLine(" Enter Name");
                string name = Console.ReadLine();

                Console.WriteLine(" Set PIN");
                int pin = int.Parse(Console.ReadLine());

                DateTime actDate = DateTime.Now;

                Console.WriteLine("DOB (dd/mm/yyyy) ");
                DateTime dob = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Gender (Male = M/Female = F/Other = O)");
                char gender = char.Parse(Console.ReadLine());

                Console.WriteLine("Enter Phone Number");
                string phoneno = Console.ReadLine();

                Console.WriteLine("Enter Email ID");
                string email = Console.ReadLine();

                Console.WriteLine("Do you want to receive the SMS Notification: (Y/N)");
               
                char Choice = char.Parse(Console.ReadLine());
                if (Choice.Equals('y') || Choice.Equals('Y'))
                    savings.ActivateSMS = true;
                else
                    savings.ActivateSMS = false;
                bool smsch = savings.ActivateSMS;
                Console.WriteLine("Do you want to receive the Email Notification: (Y/N)");
                Choice = char.Parse(Console.ReadLine());
                if (Choice.Equals('y') || Choice.Equals('Y'))
                    savings.ActivateEmail = true;
                    
                else
                    savings.ActivateEmail = false;
                bool emailch = savings.ActivateEmail;

                //DateTime dOB, char gender, string phoneNo, string name, int pin, DateTime activationdate
                SavingAccount sobj = new SavingAccount(dob, gender, name, phoneno, email, pin, actDate, smsch, emailch);
                sobj.Privilge = Privilege.SILVER;

                try
                {
                    if (managerObj.OpenAccount(sobj, "Saving"))
                    {
                        Console.WriteLine("saving acc has been created");
                       
                    }
                    else
                        Console.WriteLine("Sorry... plz try again after sometime");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            //Getting Current Account detail.................
            else if (choice == 2)
            {

                Console.WriteLine(" Enter Name");
                string name = Console.ReadLine();

                Console.WriteLine(" Set PIN");
                int pin = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Phone Number");
                string phoneno = Console.ReadLine();

                Console.WriteLine("Enter Email ID");
                string email = Console.ReadLine();

                DateTime actDate = DateTime.Now;

                Console.WriteLine("Enter CompanyName");
                string cmpyName = Console.ReadLine();

                Console.WriteLine("Website");
                string website = Console.ReadLine();

                Console.WriteLine("Registration Number:");
                string regNo = Console.ReadLine();

                Console.WriteLine("Do you want to receive the SMS Notification:(Y/N)");

                bool smsch, emailch;
                char Choice = char.Parse(Console.ReadLine());
                if (Choice.Equals('y') || Choice.Equals('Y'))
                    smsch = true;
                else
                    smsch = false;
                
                Console.WriteLine("Do you want to receive the Email Notification: (Y/N)");
                string activateEmail = Console.ReadLine();
                if (Choice.Equals('y') || Choice.Equals('Y'))
                    emailch = true;
                else
                    emailch = false;

                CurrentAccount current = new CurrentAccount(cmpyName, website, regNo, name, phoneno, email, pin, actDate, smsch, emailch);
                current.Privilge = Privilege.SILVER;

                //string companyName, string website, int registration, string name, int pin, DateTime activationdate

                try
                {
                    if (managerObj.OpenAccount(current, "Current"))
                    {
                        Console.WriteLine("current acc has been created");
                    }
                    else
                        Console.WriteLine("Sorry... plz try again after sometime");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("We dont have that facility");
            }

        }

        // for Close Account ....................
        public void CloseAccount()
        {
            Console.WriteLine("Are u sure want to close the account ? (Y/N)");
            char Choice = char.Parse(Console.ReadLine());
            if (Choice == 'y' || Choice == 'Y')
            {
                Console.Write("Please enter the Account Number :\n");
                int accNo = int.Parse(Console.ReadLine());
                Console.Write("Please enter the pin for your Account :\n");
                int pin = int.Parse(Console.ReadLine());

                // check whether this is saving or current account then closed .............
                Account accountTobeClosed = AllAccountsRepo.getAccount(accNo);
                //string accType;
                //if (accountTobeClosed is SavingAccount)
                //{
                //    accType = "Saving";
                //}
                //else accType = "Current";
                try
                {
                    if (managerObj.CloseAccount(accountTobeClosed, pin))
                    {
                        Console.WriteLine("Account has been Closed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
        }

        //Withdraw the Money from user account..............
        public void Withdraw()
        {
            Console.WriteLine("Do you want to Withdraw money ? (Y/N)");
            char choice = char.Parse(Console.ReadLine());
            if (choice == 'y' || choice == 'Y')
            {
                Console.WriteLine("please enter the account number");
                int accNo = int.Parse(Console.ReadLine());
                Console.WriteLine("please enter the pin for your account");
                int pin = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter amount to be withdrawled...");
                double withdrawAmt = double.Parse(Console.ReadLine());
                try
                {
                    if (managerObj.Withdraw(accNo, pin, withdrawAmt))
                    {
                        Console.WriteLine("amount been debited from your account ");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        // Deposit the Money from user account..............
        public void Deposit(int accNo)
        {
            Console.WriteLine("Enter amount to be deposited...");
            double depositAmt = double.Parse(Console.ReadLine());
            try
            {
                if (managerObj.Deposit(accNo, depositAmt))
                {
                    Console.WriteLine("amount been deposited into your account ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        // Transfer Money one account to other account ...............
        public void Transfer(int senderAccNo, int receiverAccNo)
        {
            Console.WriteLine("Enter amount to be transferred...");
            double transferAmt = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter pin for your account...");
            int pin = int.Parse(Console.ReadLine());
            Console.WriteLine("choose the mode of transfer\t   1.NEFT   2.RTGS   3.IMPS");
            int mot = int.Parse(Console.ReadLine());

            try
            {
                if (managerObj.Transfer(senderAccNo, receiverAccNo, transferAmt, pin, mot))
                {
                    Console.WriteLine("Money Transfer is Successfull!!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        // User Account Details .........................
        public void GetAccountDetails(int accNo, int pin)
        {
            try
            {
                Account acc = AllAccountsRepo.getAccount(accNo);

                Console.WriteLine();
                Console.Write("Name:" + acc.Name + "\n");
                Console.Write("Account number:" + acc.AccountNo + "\n");
                Console.Write("Balance:" + acc.Balance + "\n");
                Console.Write("Phone Number:" + acc.PhoneNo + "\n");
                Console.Write("Email Id:" + acc.Email + "\n");
                if (acc.IsActive)
                {
                    Console.Write("Status: Active\n");
                    Console.WriteLine("Activation Date: " + acc.ActivationDate + "\n");
                }
                else
                {
                    Console.Write("Status: Inactive\n");
                    Console.WriteLine("ClosedDate : " + acc.ClosedDate + "\n");
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public void GetTransactionDetails(int accountNo, int pin)
        {
            try
            {
                Account acc = AllAccountsRepo.getAccount(accountNo);
                List<Transaction> transactions = TransactionLog.GetAllTransfersFromLog();
                foreach (Transaction transaction in transactions)
                {
                    Console.WriteLine(transaction.TransactionType);
                    Console.WriteLine(transaction.Amount);
                    if (transaction.TransactionType.Equals("Transfer"))
                    {
                        Console.WriteLine(transaction.Mode + "\t" + transaction.SenderAccount.AccountNo + "\t" + transaction.ReceiverAccount.AccountNo);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




        }
    }
}