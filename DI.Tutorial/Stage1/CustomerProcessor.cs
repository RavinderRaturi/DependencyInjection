using System;

namespace Stage1
{
    internal class CustomerProcessor
    {
        internal void UpdateCustomerOrder(string customerName, string product)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            ProductRepository productRepository = new ProductRepository();

            customerRepository.Save();
            productRepository.Save();

            Console.WriteLine(string.Format("Customer record for '{0}' updated with purchase of product '{1}'.", customerName, product));
        }
    }
}