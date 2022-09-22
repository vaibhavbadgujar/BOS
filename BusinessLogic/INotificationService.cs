using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfSuccess.BusinessLogic
{

    //delegate void NotificationService();
    interface INotificationService
        {
            public void GenerateNotification(Notification notification);
        }
 }
