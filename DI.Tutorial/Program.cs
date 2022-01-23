using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("");
                Console.WriteLine("1 - Stage 1");
                Console.WriteLine("2 - Stage 2");
                Console.WriteLine("3 - Stage 3");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("");
                Console.WriteLine("Start Demo: ");
                string choice = Console.ReadLine();
                if (choice == "0")
                {
                    exit = true;
                }
                else
                {
                    OrderInfo orderInfo = new OrderInfo()
                    {
                        CustomerName = "Ravinder Raturi",
                        Email = "ravinderraturi@mail.com",
                        Product = "Mac Book",
                        Price = 15000,
                        CreditCard = "123XXXXXXXX343"
                    };

                    Console.WriteLine();
                    Console.WriteLine("Order Processing");
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1":
                            #region Stage 1
                            Stage1.Commerce commerce1 = new Stage1.Commerce();
                            commerce1.ProcessingOrder(orderInfo);
                            #endregion
                            break;
                        case "2":
                            #region Stage 2
                            Stage2.Commerce commerce2 =
                                new Stage2.Commerce(
                                    new Stage2.BillingProcessor(),
                                    new Stage2.CustomerProcessor(
                                        new Stage2.CustomerRepository(),
                                        new Stage2.ProductRepository()),
                                    new Stage2.Notifier());
                            commerce2.ProcessingOrder(orderInfo);
                            #endregion
                            break;
                        case "3":
                            //do something
                            break;
                    }

                }
            }
        }
    }
}
