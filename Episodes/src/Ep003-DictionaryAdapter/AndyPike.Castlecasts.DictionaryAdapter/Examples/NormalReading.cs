using System;
using System.Collections;

namespace AndyPike.Castlecasts.DictionaryAdapter.Examples
{
    public class NormalReading : ISample
    {
        public void Run()
        {
            IDictionary dictionary = new Hashtable
                                             {
                                                 {"Title", "The Castle Manual"},
                                                 {"Price", "10.99"}
                                             };

            Console.WriteLine("Title: {0}", dictionary["Title"]);
            Console.WriteLine("Price: £{0}", dictionary["Price"]);
        }
    }
}