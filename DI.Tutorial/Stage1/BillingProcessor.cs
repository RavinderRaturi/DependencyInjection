using System;

namespace Stage1
{
    internal class BillingProcessor
    {
        internal void ProcessPayment(string customerName, string creditCard, int price)
        {
            Console.WriteLine("Payment processed for Customer '{0}' on credit card {1} for ${2}.", customerName, creditCard, price);
        }
    }
}