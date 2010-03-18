using System;
using System.Collections;
using Castle.Components.DictionaryAdapter;

namespace AndyPike.Castlecasts.DictionaryAdapter.Examples
{
    public class NestedObjects : ISample
    {
        public interface IOrder
        {
            [DictionaryComponent]
            IOrderItem Item { get; set; }

            [DictionaryComponent]
            ICustomer Customer { get; set; }
        }

        public interface ICustomer
        {
            string Name { get; set; }
            string Phone { get; set; }
        }

        public interface IOrderItem
        {
            string Description { get; set; }
            int Quantity { get; set; }
        }

        public void Run()
        {
            IDictionary dictionary = new Hashtable
                                             {
                                                 {"Item_Description", "Standard Tiles"},
                                                 {"Item_Quantity", "10"},
                                                 {"Customer_Name", "Mr Pike"},
                                                 {"Customer_Phone", "123 456 789"}
                                             };

            var factory = new DictionaryAdapterFactory();
            var order = factory.GetAdapter<IOrder>(dictionary);

            Console.WriteLine("Item Description: {0}", order.Item.Description);
            Console.WriteLine("Item Quantity: {0}", order.Item.Quantity);
            Console.WriteLine("Customer Name: {0}", order.Customer.Name);
            Console.WriteLine("Customer Phone: {0}", order.Customer.Phone);
        }
    }
}