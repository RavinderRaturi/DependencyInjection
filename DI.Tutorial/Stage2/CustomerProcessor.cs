using System;

namespace DI.Tutorial.Stage2
{
    public class CustomerProcessor : ICustomerProcessor
    {
         ICustomerRepository _customerRepository;
         IProductRepository _productRepository;

        public CustomerProcessor(ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }
         void ICustomerProcessor.UpdateCustomerOrder(string customerName, string product)
        {
            
            _customerRepository.Save();
            _productRepository.Save();

            Console.WriteLine(string.Format("Customer record for '{0}' updated with purchase of product '{1}'.", customerName, product));
        }
    }

    public interface ICustomerProcessor
    {
        void UpdateCustomerOrder(string customerName, string product);
    }
}