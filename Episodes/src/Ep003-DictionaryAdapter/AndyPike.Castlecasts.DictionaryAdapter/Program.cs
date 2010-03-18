using System;
using AndyPike.Castlecasts.DictionaryAdapter.Examples;

namespace AndyPike.Castlecasts.DictionaryAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var samples = new ISample[] 
            { 
                new NormalReading(), 
                new SimpleAdapter(), 
                new TwoWayAdapter(),
                new ListSample(), 
                new UseAppSettings(), 
                new CustomKeys(),
                new CustomPrefix(),
                new NestedObjects()
            };

            for (int i = 0; i < samples.Length; i++)
            {
                Console.WriteLine("{0}: {1}", i, samples[i].GetType().Name);
            }

            while (true)
            {
                Console.Write("\r\nSelect a sample number to run...");

                int sampleIndex = int.Parse(Console.ReadLine());
                ISample sample = samples[sampleIndex];
                Console.WriteLine("\r\n{0}:", sample.GetType().Name);
                sample.Run();
            }
        }
    }
}
