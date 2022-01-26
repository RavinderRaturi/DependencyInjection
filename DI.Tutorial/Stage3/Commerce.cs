using DI.Tutorial;
using System;

namespace DI.Tutorial.Stage3
{
    public class Commerce
    {
        private IBillingProcessor _BillingProcessor;
        private ICustomerProcessor _CustomerProcessor;
        private INotifier _Notifier;

        public Commerce(IBillingProcessor billingProcessor, ICustomerProcessor customerProcessor, INotifier notifier)
        {
            _BillingProcessor = billingProcessor;
            _CustomerProcessor = customerProcessor;
            _Notifier = notifier;
        }

        public void ProcessingOrder(OrderInfo orderInfo)
        {

            _BillingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _CustomerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _Notifier.SendRecipt(orderInfo);
        }
    }
}