using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.MVC
{
   public interface ICustomerRepository
    {
        Customer GetById(int id);
        List<Customer> GetAll();
        void Update(Customer customer);
    }
}
