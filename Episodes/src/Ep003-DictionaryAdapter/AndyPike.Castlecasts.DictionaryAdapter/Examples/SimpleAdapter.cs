using System;
using System.Collections;
using Castle.Components.DictionaryAdapter;

namespace AndyPike.Castlecasts.DictionaryAdapter.Examples
{
    public class SimpleAdapter : ISample
    {
        public interface IProduct
        {
            string Title { get; set; }
            float? Price { get; set; }
        }

        public void Run()
        {
            IDictionary dictionary = new Hashtable
                                             {
                                                 {"Title", "The Castle Manual"},
                                                 {"Price", "10.99"}
                                             };

            var factory = new DictionaryAdapterFactory();
            var settings = factory.GetAdapter<IProduct>(dictionary);

            Console.WriteLine("Title: {0}", settings.Title);
            Console.WriteLine("Price: £{0}", settings.Price);
        }
    }
}