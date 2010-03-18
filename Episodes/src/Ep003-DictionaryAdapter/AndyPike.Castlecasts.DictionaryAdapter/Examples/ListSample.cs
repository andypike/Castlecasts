using System;
using System.Collections;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;

namespace AndyPike.Castlecasts.DictionaryAdapter.Examples
{
    public class ListSample : ISample
    {
        public interface IListSample
        {
            [StringList]
            IList<string> Names { get; set; }
        }

        public void Run()
        {
            IDictionary list = new Hashtable
                                   {
                                       {"Names", "Andy,Megan,Amber,Charlie,Michela"}
                                   };
            var listSample = new DictionaryAdapterFactory().GetAdapter<IListSample>(list);
            foreach (var name in listSample.Names)
            {
                Console.WriteLine("Name: {0}", name);
            }
        }
    }
}