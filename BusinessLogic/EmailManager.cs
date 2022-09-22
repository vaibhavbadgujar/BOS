using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Services;
using System.Reactive;
using BankOfSuccess.BusinessLogic;

namespace BankOfSuccess.BusinessLogic
{
    internal class EmailManager : INotificationService
    {
        public void GenerateNotification(Notification notification)
        {
            string body;
            //MailMessage mail;
            if (notification.EmailActive)
            {
                if (notification.Amount == 0.0)
                {
                    body = GetBody(notification);
                    GenerateEmail(notification, body);
                    NotificationLog.AddInLog(notification);
                }
                else
                {
                    body = GetUpdateBody(notification);
                    GenerateEmail(notification, body);
                    NotificationLog.AddInLog(notification);
                }
            }
            else
            {
                body = GetNewUserBody(notification);
                GenerateEmail(notification, body);
            }
        }

        public void GenerateEmail(Notification notification, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("bankofsuccess2022@gmail.com");
                mail.To.Add(notification.Email);
                mail.Subject = "Bank Account related mail";
                mail.Body = body;
                mail.IsBodyHtml = true;
                // mail.Attachments.Add(new Attachment("C:\\file.zip"));
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("bankofsuccess2022@gmail.com", "rfrqkuypzxsghsxv");
                    smtp.Send(mail);
                }

            }
        }


        private string GetNewUserBody(Notification notification)
        {
            string body = "Hello " + notification.Name + ",<br>Would you like to receive Email Notifications.?\n<br>Please contact Bank of Success Private Limited";
            return body;
        }
        private string GetUpdateBody(Notification notification)
        {
            string body = "Hello " + notification.Name + ",\n<br><br>Welcome to Bank of Success notification service.<br><br>Account Details:\n<br>Account Number:" + notification.AccountNumber +
               "\n<br>Account Balance:" + notification.Balance + "\n<br>Deposit/Withdraw:" + notification.Amount + "\n<br>Operation happened at " + DateTime.Now + "<br><br> Bank Of Success Pvt Ltd";
            return body;
        }

        private string GetBody(Notification notification)
        {
            string msg;
            if (notification.IsActive)
                msg = "Activation Date:";
            else
                msg = "Closed Date:";
            string body = "Hello " + notification.Name + ",\n<br><br>Welcome to Bank of Success notification service.<br><br>Account Details:\n<br>Account Number:" + notification.AccountNumber +
               "\n<br>Account Balance:" + notification.Balance + "\n<br>" + msg + DateTime.Now + "\n<br><br> Bank of Success Pvt Ltd ";
            return body;
        }

    }
}
