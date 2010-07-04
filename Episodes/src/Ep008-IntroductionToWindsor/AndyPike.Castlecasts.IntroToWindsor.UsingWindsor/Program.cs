using System;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace AndyPike.Castlecasts.IntroToWindsor.UsingWindsor
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer(new XmlInterpreter("Windsor.config"));

            container
                .AddComponent<ILogger, FileLogger>()
                .AddComponent<INotifier, SmsSender>()
                .AddComponent<IOrderProcessingService, OrderProcessingService>();

            var orderProcessingService = container.Resolve<IOrderProcessingService>();
            orderProcessingService.PlaceOrder(new Order());
            
            Console.ReadLine();
        }
    }
}
