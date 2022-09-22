using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfSuccess.UI;
using BankOfSuccess.BusinessLogic;
using BankOfSuccess.Entities;


public class MyMainClass
{
    public static void Main(string[] args)
    {

        //Console.WriteLine(TransferLimitManager.GetTransferLimit(new Privilege()));



        Console.WriteLine("*---------------Welcome To Bank Of Success---------------*\n\n");
        AccountForm form = new AccountForm();
        bool i = true;
        while (i==true)
        {
           
            Console.WriteLine("\n\t\t Choose from below :-----------");
            Console.WriteLine("\t\t 1. Create an Account");
            Console.WriteLine("\t\t 2. Withdraw Money from Account");
            Console.WriteLine("\t\t 3. Deposit Money into Account");
            Console.WriteLine("\t\t 4. Get Details of an Account");
            Console.WriteLine("\t\t 5. Transfer Money");
            Console.WriteLine("\t\t 6. Get All Tranctions for an Account");
            Console.WriteLine("\t\t 7. Close Account ");
            Console.WriteLine("\t\t 8. EXIT");
            int ch;
            try
            {
                 ch = int.Parse(Console.ReadLine());
            
                int accNo;
                switch (ch)
                {
                    case (1):
                        form.OpenAccount();
                         break;
                    case (2):
                        form.Withdraw();
                         break;
                    case (3):
                        Console.WriteLine("Do you want to Deposit money ? (Y/N)");

                        char choice = char.Parse(Console.ReadLine());
                        if (choice == 'y' || choice == 'Y')
                        {
                            Console.WriteLine("please enter the account number");
                            accNo = int.Parse(Console.ReadLine());

                            form.Deposit(accNo);
                        }
                         break;
                    case (4):
                        Console.WriteLine("please enter the account number for details.");
                        accNo = int.Parse(Console.ReadLine());
                        Console.WriteLine("please enter the pin number");
                        int pin = int.Parse(Console.ReadLine());
                        form.GetAccountDetails(accNo, pin);
                         break;
                    case (5):
                        Console.WriteLine("Do you want to transfer money ? (Y/N)");
                        choice = char.Parse(Console.ReadLine());
                        if (choice == 'y' || choice == 'Y')
                        {
                            Console.WriteLine("Enter sender's account no");
                            int sAccNo = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter receiver's account no");
                            int rAccNo = int.Parse(Console.ReadLine());
                            form.Transfer(sAccNo, rAccNo);
                        }
                         break;
                        case (6):
                        Console.WriteLine("Please enter the account number for transaction details. ");
                        accNo = int.Parse(Console.ReadLine());
                        Console.WriteLine("please enter pin for ypur account ");
                        pin = int.Parse(Console.ReadLine());
                        form.GetTransactionDetails(accNo, pin);
                        break;
                        case (7):
                        form.CloseAccount();
                        break;
                    case (8):
                        i = false;
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\t\t\t\t----------Thankyou For visiting BankOfSuccess---------- ");
                        Thread.Sleep(1000);
                        break;
                    
                    default:

                        break;

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }



        }
    }
}

