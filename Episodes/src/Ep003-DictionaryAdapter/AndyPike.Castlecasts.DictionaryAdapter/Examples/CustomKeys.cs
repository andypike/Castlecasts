using System;
using System.Collections;
using Castle.Components.DictionaryAdapter;

namespace AndyPike.Castlecasts.DictionaryAdapter.Examples
{
    public class CustomKeys : ISample
    {
        public interface IShape
        {
            [DictionaryKey("Designation")]
            string Name { get; set; }

            [DictionaryKey("Hue")]
            string Colour { get; set; }

            [DictionaryKey("Faces")]
            int Sides { get; set; }
        }

        public void Run()
        {
            IDictionary dictionary = new Hashtable
                                             {
                                                 {"Designation", "Square"},
                                                 {"Hue", "Red"},
                                                 {"Faces", "4"}
                                             };

            var factory = new DictionaryAdapterFactory();
            var shape = factory.GetAdapter<IShape>(dictionary);

            Console.WriteLine("Name: {0}", shape.Name);
            Console.WriteLine("Colour: {0}", shape.Colour);
            Console.WriteLine("Sides: {0}", shape.Sides);
        }
    }
}