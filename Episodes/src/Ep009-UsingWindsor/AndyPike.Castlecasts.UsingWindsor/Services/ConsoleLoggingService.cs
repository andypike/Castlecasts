using System;

namespace AndyPike.Castlecasts.UsingWindsor.Services
{
    public class ConsoleLoggingService : ILoggingService
    {
        public void Info(string message)
        {
            Console.WriteLine("INFO: " + message);
        }
    }
}