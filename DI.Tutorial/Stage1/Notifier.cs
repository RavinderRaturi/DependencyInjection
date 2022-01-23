using DI.Tutorial;
using System;

namespace Stage1
{
    internal class Notifier
    {
        internal void SendRecipt(OrderInfo orderInfo)
        {
            Console.WriteLine(string.Format("Receipt sent for customer '{0}' via email.",orderInfo.CustomerName));

        }
    }
}