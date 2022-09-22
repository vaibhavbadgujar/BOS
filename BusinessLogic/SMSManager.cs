using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace BankOfSuccess.BusinessLogic
{
    internal class SMSManager:INotificationService
    {
        public void GenerateNotification(Notification notification)
        {
            //Notification notification = SMSEmailNotification.GetSMSEmailNotification();

            try
            {
                if (Login())
                    if (notification.SMSActive)
                    {
                        if (CreateMessage(notification))
                            NotificationLog.AddInLog(notification);
                    }
                    else
                        CreateNewUserMessage(notification);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return islogin;
        }

        private bool Login()
        {
            bool islogin = false;
            string username = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string password = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");
            TwilioClient.Init(username, password);
            islogin = true;

            return islogin;
        }

        private bool CreateMessage(Notification notification)
        {
            string msg;
            if (notification.IsActive)
                msg = "Activation Date:";
            else
                msg = "Closed Date:";

            string body = "Hello " + notification.Name + ",\nAccount Details:\nAccount Number:" + notification.AccountNumber +
               "\nAccount Balance:" + notification.Balance + "\n" + msg + DateTime.Now + "\n ";
            var message = MessageResource.Create(
                                body: body,
                                from: new Twilio.Types.PhoneNumber("+17079853543"),
                                to: new Twilio.Types.PhoneNumber("+91" + notification.PhoneNumber)
                            );
            //Console.WriteLine(message.Sid);
            return true;
        }
        private bool CreateNewUserMessage(Notification notification)
        {
            string body = "Hello " + notification.Name + ",\n Would you like to activate notification services.?\n Please contact Bank of Success";
            var message = MessageResource.Create(
                                body: body,
                                from: new Twilio.Types.PhoneNumber("+17079853543"),
                                to: new Twilio.Types.PhoneNumber("+91" + notification.PhoneNumber)
                            );
            //Console.WriteLine(message.Sid);
            return true;
        }
    }
}
