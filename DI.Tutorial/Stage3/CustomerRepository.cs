using System;

namespace DI.Tutorial.Stage3
{
    public class CustomerRepository : ICustomerRepository
    {
        ILogger _Logger;
        public CustomerRepository(ILogger logger)
        {
            _Logger = logger;
        }

        void ICustomerRepository.Save()
        {
            _Logger.Log("This is CustomerRepository logger.");
            Console.WriteLine("Customer purchase saved.");
        }
    }

    public interface ICustomerRepository
    {
        void Save();
    }
}