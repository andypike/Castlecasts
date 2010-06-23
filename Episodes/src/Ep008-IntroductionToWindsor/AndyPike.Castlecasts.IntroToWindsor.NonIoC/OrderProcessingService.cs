namespace AndyPike.Castlecasts.IntroToWindsor.NonIoC
{
    public class OrderProcessingService
    {
        public void PlaceOrder(Order order)
        {
            var repository = new NHibernateRepository<Order>();
            var notifier = new PlainTextEmailer();

            repository.Save(order);
            notifier.Send(order.Customer, "Your order was successfully processed.");
        }
    }
}