using System;

namespace AndyPike.Castlecasts.IntroToWindsor.UsingWindsor
{
    public class SmsSender : INotifier
    {
        public void Send(Customer customer, string message)
        {
            Console.WriteLine("Sending SMS to customer");
        }
    }
}