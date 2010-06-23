using System;

namespace AndyPike.Castlecasts.IntroToWindsor.UsingWindsor
{
    public class OrderProcessingService : IOrderProcessingService
    {
        private readonly IRepository<Order> repository;
        private readonly INotifier notifier;

        public OrderProcessingService(IRepository<Order> repository, 
                                      INotifier notifier)
        {
            this.repository = repository;
            this.notifier = notifier;
        }

        public void PlaceOrder(Order order)
        {
            Console.WriteLine("Inside PlaceOrder");

            repository.Save(order);
            
            notifier.Send(order.Customer, "Your order was successfully processed.");
        }
    }
}