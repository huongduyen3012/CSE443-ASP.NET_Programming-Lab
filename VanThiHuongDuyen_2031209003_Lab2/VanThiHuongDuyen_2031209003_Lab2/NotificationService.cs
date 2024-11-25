using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanThiHuongDuyen_2031209003_Lab2
{
    class NotificationService
    {
        public virtual void SendNotification(string message)
        {
            Console.WriteLine($"Notification: {message}");
        }

        void SendNotification(string message, string recipient)
        {
        }

        void SendNotification(string message, List<string> recipients)
        {
        }
    }

    class AdvancedNotificationService : NotificationService
    {
        public override void SendNotification(string message)
        {
            Console.WriteLine($"Timestamp:{DateTime.Now}\nNotification: {message}");
        }
    }
}
