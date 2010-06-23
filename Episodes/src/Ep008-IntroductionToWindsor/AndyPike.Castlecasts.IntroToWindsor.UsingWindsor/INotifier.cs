namespace AndyPike.Castlecasts.IntroToWindsor.UsingWindsor
{
    public interface INotifier
    {
        void Send(Customer customer, string message);
    }
}