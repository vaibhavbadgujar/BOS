using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfSuccess;
using BankOfSuccess.BOSDb;
using BankOfSuccess.BusinessLogic;
using BankOfSuccess.Entities;



namespace BankOfSuccess.BusinessLogic
{
    internal class AccountManager
    {
        //AllAccountsRepo repository = new AllAccountsRepo();

        // Calling the Account Implement for Create a account types (saving and current) .............
        public static AccountImplementation Create(String accountType)
        {
            AccountImplementation accountImplementation;
            if (accountType.Equals("Saving"))
            {
                accountImplementation = new SavingAccountImplementation();

            }
            else
            {
                accountImplementation = new CurrentAccountImplementation();
            }
            return accountImplementation;
        }
        // closeaccount from accountForm is calling this close in accmanager...........
        private bool Close(Account accountTobeClosed,int pin)
        {
            bool isAccClosed = false;

            if (!isAccountActive(accountTobeClosed))
            {
                throw new AccountIsAlreadyInactiveException("This Account Is Already Inactive !!!");
            }
            else if(CheckIfPinIsValid(accountTobeClosed,pin))
            {
                accountTobeClosed.IsActive = false;
                accountTobeClosed.ClosedDate = DateTime.Now;
                isAccClosed = true;
                NotificationFactory.SendNotification(accountTobeClosed, 0.0);
            }
            return isAccClosed;
        }
        // Withdraw from accountForm is calling this WithdrawFund in accmanager..............
        private bool WithdrawFund(int accountNo, int pin, double Amount)
        {
            bool isWithdrawl = false;
            try
            {
               Account account = AllAccountsRepo.getAccount(accountNo);
                if (isAccountActive(account))
                {
                    if (account.Balance < Amount)
                    {
                        throw new InsufficientBalanceException("Insufficient Balance !!!");
                    }
                    else if (CheckIfPinIsValid(account,pin))
                    {
                        if (withdraw(account, Amount)) isWithdrawl = true;
                        Transaction transaction = new Transaction(account, null, Amount, TransferMode.invallid, DateTime.Now, "Withdraw");
                        TransactionLog.AddToLog(transaction);
                        NotificationFactory.SendNotification(account, 0.0);
                    }
                }
                else throw new AccountIsAlreadyInactiveException("Account is Inactive !!!");
            }
            catch (InvalidPINException ex) { throw; }
            catch (AccountNotFoundException ex) { throw; }
            catch (InsufficientBalanceException ex) { throw; }
            catch (AccountIsAlreadyInactiveException ex) { throw; }

            return isWithdrawl;
        }
        // Deposit from accountForm is calling this DepositFund in accmanager............
        private bool DepositFund(int accountNo, double Amount)
        {
            bool isDeposited = false;
            try
            {
                Account account = AllAccountsRepo.getAccount(accountNo);
                if (isAccountActive(account))
                {
                    if (deposit(account, Amount)) isDeposited = true;
                    Transaction transaction = new Transaction(null, account, Amount, TransferMode.invallid, DateTime.Now, "Deposit");
                    TransactionLog.AddToLog(transaction);
                    NotificationFactory.SendNotification(account, 0.0);
                }
                else throw new AccountIsAlreadyInactiveException("Account is Inactive !!!");
            }
            catch (AccountNotFoundException ex) { throw; }
            catch (AccountIsAlreadyInactiveException ex) { throw; }
            return isDeposited;

        }
        //private deposit helper function..............
        private bool deposit(Account acc, double amt)
        {
            acc.Balance += amt;
            return true;
        }
        private bool withdraw(Account acc, double amt)
        {
            acc.Balance -= amt;
            return true;
        }
        // Transfer from accountForm is calling this TransferFund in accmanager............
        private bool TransferFund(int senderAccNo, int receiverAccNo, double amount, int pin, int mot)
        {
            bool isTransferred = false;
            
            try
            {
                Account sender = AllAccountsRepo.getAccount(senderAccNo);
                Account receiver = AllAccountsRepo.getAccount(receiverAccNo);
                if (WithdrawFund(senderAccNo, pin, amount))
                {
                    double dailyTransferLimit = TransferLimitManager.GetTransferLimit(sender.Privilge);
                    TransferLog obj = new TransferLog();
                    List<FundTransfer> totalTransfersDoneYet = obj.GetTransfers(sender);
                    double TotalAmt = 0;
                    foreach (FundTransfer trans in totalTransfersDoneYet)
                    {
                        TotalAmt += trans.amount;
                    }
                    if (dailyTransferLimit > (TotalAmt + amount))
                    {
                        if (DepositFund(receiverAccNo, amount))
                        {
                            FundTransfer transfer = new FundTransfer();
                            transfer.sender = sender;
                            transfer.receiver = receiver;
                            transfer.timeOfTransfer = DateTime.Now;
                            transfer.amount = amount;
                            if (mot == 1)
                            {
                                transfer.modeOfTransfer = TransferMode.NEFT;
                            }
                            else if (mot == 2)
                            {
                                transfer.modeOfTransfer = TransferMode.RTGS;
                            }
                            else transfer.modeOfTransfer = TransferMode.IMPS;
                            TransferLog.addTransferDetails(transfer);
                            Transaction transaction = new Transaction(sender, receiver, amount, transfer.modeOfTransfer, DateTime.Now, "Transfer");
                            TransactionLog.AddToLog(transaction);
                            isTransferred = true;
                            NotificationFactory.SendNotification(sender, 0.0);
                            NotificationFactory.SendNotification(receiver, 0.0);
                        }
                    }
                    else { throw new dailyTransferlimitHasReachedException("Daily Transfer Lmit Has Reached !!!"); }
                }

            }
            catch (InvalidPINException ex) { throw; }
            catch (AccountNotFoundException ex) { throw; }
            catch (InsufficientBalanceException ex) { throw; }
            catch (AccountIsAlreadyInactiveException ex) { throw; }
            catch (dailyTransferlimitHasReachedException ex) { throw; }
            return isTransferred;
        }
        // checking the account is active or not ..............
        private bool isAccountActive(Account account)
        {
            if (!account.IsActive)
            {
                return false;
            }
            else return true;
        }
        
        public bool OpenAccount(Account AccountTobeOpened, string AccountType)
        {
            bool isAccountopened = false;
            //dynamic polymorphism
            try
            {
                AccountImplementation accImplementation = Create(AccountType);
                if (accImplementation.OpenAccount(AccountTobeOpened))
                {
                    isAccountopened = true;
                 
                  // AccountRepository.SaveAccount(AccountTobeOpened);
                }
            }
            catch (Exception ex) { throw; }
            
            return isAccountopened;

        }

        public bool CloseAccount(Account accountTobeClosed,int pin)
        {
            bool isAccountClosed = false;
            
            try
            {
                if (Close(accountTobeClosed,pin)) isAccountClosed = true;
            }
            catch (AccountIsAlreadyInactiveException ex) { throw; }
           
            return isAccountClosed;
        }

        
        public bool Withdraw(int accNo, int pin, double WithdrawlAmount)
        {
            bool isAmountWithdrawn = false;
            
            try
            {
                isAmountWithdrawn = WithdrawFund(accNo, pin, WithdrawlAmount);

            }
            catch (Exception ex) { throw; }
            return isAmountWithdrawn;
        }
        public bool Deposit(int accNo, double DepositAmount)
        {
            bool isDeposited = false;
            
            try
            {
                isDeposited = DepositFund(accNo, DepositAmount);
            }
            catch (Exception ex) { throw;}
            return isDeposited;
        }


        public bool Transfer(int senderAccNo, int receiverAccNo, double transferAmt, int pin,int mot)   //passing 4 parameters
        {
            bool isTransferred = false;
            
            try
            {
                isTransferred = TransferFund(senderAccNo, receiverAccNo, transferAmt, pin, mot);

            }
            catch (Exception ex) { throw; }
            return isTransferred;


        }
        private bool CheckIfPinIsValid(Account account, int pin)
        {
            if (pin != account.PIN)
            {
                throw new InvalidPINException("Pin is not valid.");
            }
            return true;
        }
        

        
    }
}