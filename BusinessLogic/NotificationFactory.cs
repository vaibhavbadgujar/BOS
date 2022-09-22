using BankOfSuccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.BusinessLogic

{
    internal class NotificationFactory
    {
        static Notification notification = new Notification();

        private static Notification SetNotification(Account account, double amount)
        {
            Notification notification = new Notification();
            notification.AccountNumber = account.AccountNo;
            notification.Name = account.Name;
            notification.Balance = account.Balance;
            notification.PhoneNumber = account.PhoneNo;
            notification.Email = account.Email;
            notification.IsActive = account.IsActive;
            notification.SMSActive = account.ActivateSMS;
            notification.EmailActive = account.ActivateEmail;
            notification.Amount = amount;
            return notification;
        }


        public static void SendNotification(Account account, double amount)
        {
            Notification notification = SetNotification(account, amount);
            INotificationService notificationService;
            notificationService = new SMSManager();
            //notificationService.GenerateNotification(notification);
            notificationService = new EmailManager();
            notificationService.GenerateNotification(notification);

        }
    }
}
