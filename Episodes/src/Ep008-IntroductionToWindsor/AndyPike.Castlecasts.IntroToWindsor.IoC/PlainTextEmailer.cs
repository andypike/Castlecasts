namespace AndyPike.Castlecasts.IntroToWindsor.IoC
{
    public class PlainTextEmailer : INotifier
    {
        public void Send(Customer customer, string message)
        {
            //Send an email to customer.Email
        }
    }
}