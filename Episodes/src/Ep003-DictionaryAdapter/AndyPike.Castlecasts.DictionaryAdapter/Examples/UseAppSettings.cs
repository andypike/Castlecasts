using System;
using System.Configuration;
using Castle.Components.DictionaryAdapter;

namespace AndyPike.Castlecasts.DictionaryAdapter.Examples
{
    public class UseAppSettings : ISample
    {
        public interface ISimpleConfiguration
        {
            string SmtpHost { get; set; }
            int Port { get; set; }
        }

        public void Run()
        {
            var factory = new DictionaryAdapterFactory(); 
            var config = factory.GetAdapter<ISimpleConfiguration>(ConfigurationManager.AppSettings);

            Console.WriteLine("Smtp Host: {0}", config.SmtpHost);
            Console.WriteLine("Port: {0}", config.Port);
        }
    }
}