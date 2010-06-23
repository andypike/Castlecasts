namespace AndyPike.Castlecasts.IntroToWindsor.IoC
{
    public interface INotifier
    {
        void Send(Customer customer, string message);
    }
}