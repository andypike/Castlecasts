using System;
using System.Collections;
using Castle.Components.DictionaryAdapter;

namespace AndyPike.Castlecasts.DictionaryAdapter.Examples
{
    public class TwoWayAdapter : ISample
    {
        public interface IComputerPart
        {
            string Name { get; set; }
        }

        public void Run()
        {
            IDictionary dictionary = new Hashtable
                                             {
                                                 {"Name", "RAM"},
                                             };

            var factory = new DictionaryAdapterFactory();
            var part = factory.GetAdapter<IComputerPart>(dictionary);

            Console.WriteLine("Original Name: {0}", part.Name);

            part.Name = "Random Access Memory";

            Console.WriteLine("New Name: {0}", dictionary["Name"]);
        }
    }
}