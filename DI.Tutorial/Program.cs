using Autofac;
using System;
using System.Linq;
using System.Reflection;

namespace DI.Tutorial
{
    class Program
    {
        public static IContainer Container;
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

                            #region State3

                            ContainerBuilder builder = new ContainerBuilder();

                            builder.RegisterType<Stage3.Commerce>();
                            builder.RegisterType<Stage3.Notifier>().As<Stage3.INotifier>();

                            #region Regiter and Resolve if there is no standard naming convention. 
                         
                            //builder.RegisterType<Stage3.BillingProcessor>().As<Stage3.IBillingProcessor>();
                            //builder.RegisterType<Stage3.CustomerProcessor>().As<Stage3.ICustomerProcessor>();
                            //builder.RegisterType<Stage3.CustomerRepository>().As<Stage3.ICustomerRepository>();
                            //builder.RegisterType<Stage3.ProductRepository>().As<Stage3.IProductRepository>();
                       
                            
                            #endregion



                            #region Regiter and Resolve if there is proper naming convention.
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Processor") && t.Namespace.EndsWith("Stage3"))
                                .As(t => t.GetInterfaces().FirstOrDefault(
                                    i => i.Name == "I" + t.Name));

                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Repository") && t.Namespace.EndsWith("Stage3"))
                                .As(t => t.GetInterfaces().FirstOrDefault(
                                    i => i.Name == "I" + t.Name));
                            #endregion



                            builder.RegisterType<Stage3.Logger>().As<Stage3.ILogger>();

                            Container = builder.Build();

                            Stage3.Commerce commerce3 = Container.Resolve<Stage3.Commerce>();
                            commerce3.ProcessingOrder(orderInfo);
                            #endregion
                            break;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Press 'Enter' for menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
