namespace AndyPike.Castlecasts.IntroToWindsor.NonIoC
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                Decription = "iPhone 4",
                Quantity = 1,
                Customer = new Customer
                                    {
                                        Name = "Andy Pike",
                                        Email = "andy@castlecasts.com",
                                        Phone = "1234567890"
                                    }
            };
            
            //Do the following with this order:
            //  * Save the order
            //  * Log the save somewhere
            //  * Notify the customer
            var orderProcessingService = new OrderProcessingService();
            orderProcessingService.PlaceOrder(order);
        }
    }
}
