using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.BusinessLogic
{
    internal class NotificationLog
    {
        public static List<Notification> Notifications = new List<Notification>();

        public static void AddInLog(Notification notification)
        {
            Notifications.Add(notification);
        }
        public static List<Notification> GetNotification()
        {
            return Notifications;
        }
    }
}
