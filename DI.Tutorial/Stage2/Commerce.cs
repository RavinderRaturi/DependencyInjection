using DI.Tutorial;
using System;

namespace DI.Tutorial.Stage2
{
    public class Commerce
    {
        private IBillingProcessor _billingProcessor;
        private ICustomerProcessor _customerProcessor;
        private INotifier _notifier;

        public Commerce(IBillingProcessor billingProcessor, ICustomerProcessor customerProcessor,INotifier notifier)
        {
            _billingProcessor= billingProcessor;
            _customerProcessor =customerProcessor;
            _notifier= notifier;
        }

        public void ProcessingOrder(OrderInfo orderInfo)
        {    
            
            _billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _notifier.SendRecipt(orderInfo);

        }
    }
}