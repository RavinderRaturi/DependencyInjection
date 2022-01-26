using DI.Tutorial;
using System;

namespace DI.Tutorial.Stage3
{
    public class Notifier : INotifier
    {
         void INotifier.SendRecipt(OrderInfo orderInfo)
        {
            Console.WriteLine(string.Format("Receipt sent for customer '{0}' via email.",orderInfo.CustomerName));

        }
    }

    public interface INotifier
    {
        void SendRecipt(OrderInfo orderInfo);
    }
}