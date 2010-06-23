namespace AndyPike.Castlecasts.IntroToWindsor.IoC
{
    public class OrderProcessingService
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
            repository.Save(order);
            notifier.Send(order.Customer, "Your order was successfully processed.");
        }
    }
}