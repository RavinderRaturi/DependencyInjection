using System;

namespace DI.Tutorial.Stage3
{
    public class ProductRepository : IProductRepository
    {
        public void Save()
        {
            Console.WriteLine("Product inventory updated.");
        }
    }

     public interface IProductRepository
    {
        void Save();
    }
}