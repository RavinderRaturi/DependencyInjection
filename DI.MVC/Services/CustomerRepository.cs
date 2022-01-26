using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DI.MVC
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetById(int id)
        {
            List<Customer> customers = GetAll();
            return customers.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>()
            {
            new Customer(){ Id=1,Name="Ravinder",Email="abc@gmail.com"},
            new Customer(){ Id=2,Name="Josh",Email="ddd@gmail.com"},

            };
            return customers;
        }
        public void Update(Customer customer)
        {
            Console.WriteLine("Customer update.");
        }
    }
}