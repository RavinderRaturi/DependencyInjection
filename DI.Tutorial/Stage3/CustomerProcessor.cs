using System;

namespace DI.Tutorial.Stage3
{
    public class CustomerProcessor : ICustomerProcessor
    {
         ICustomerRepository _CustomerRepository;
         IProductRepository _ProductRepository;

        public CustomerProcessor(ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _CustomerRepository = customerRepository;
            _ProductRepository = productRepository;
        }
         void ICustomerProcessor.UpdateCustomerOrder(string customerName, string product)
        {
            
            _CustomerRepository.Save();
            _ProductRepository.Save();

            Console.WriteLine(string.Format("Customer record for '{0}' updated with purchase of product '{1}'.", customerName, product));
        }
    }

    public interface ICustomerProcessor
    {
        void UpdateCustomerOrder(string customerName, string product);
    }
}