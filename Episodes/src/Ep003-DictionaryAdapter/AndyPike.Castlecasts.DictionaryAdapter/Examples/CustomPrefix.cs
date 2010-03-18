using System;
using System.Collections;
using Castle.Components.DictionaryAdapter;

namespace AndyPike.Castlecasts.DictionaryAdapter.Examples
{
    public class CustomPrefix : ISample
    {
        [DictionaryKeyPrefix("My")]
        public interface IPerson
        {
            string Name { get; set; }
            int Age { get; set; }
        }

        public void Run()
        {
            IDictionary dictionary = new Hashtable
                                             {
                                                 {"MyName", "Andy"},
                                                 {"MyAge", "32"}
                                             };

            var factory = new DictionaryAdapterFactory();
            var person = factory.GetAdapter<IPerson>(dictionary);

            Console.WriteLine("Name: {0}", person.Name);
            Console.WriteLine("Age: {0}", person.Age);
        }
    }
}