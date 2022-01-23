using System;

namespace DI.Tutorial.Stage2
{
    public class BillingProcessor : IBillingProcessor
    {
        void IBillingProcessor.ProcessPayment(string customerName, string creditCard, int price)
        {
            Console.WriteLine("Payment processed for Customer '{0}' on credit card {1} for ${2}.", customerName, creditCard, price);
        }
    }

    public interface IBillingProcessor
    {
        void ProcessPayment(string customerName, string creditCard, int price);
    }
}