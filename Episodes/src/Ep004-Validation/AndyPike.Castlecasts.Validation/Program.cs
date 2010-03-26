using System;
using AndyPike.Castlecasts.Validation.ThingsToValidate;
using Castle.Components.Validator;

namespace AndyPike.Castlecasts.Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                Product = new Product { Name = "Widget", MinQuantity = 5, MaxQuantity = 100 },
                Quantity = 50
            };

            var runner = new ValidatorRunner(new CachedValidationRegistry());
            if (runner.IsValid(order))
            {
                Console.WriteLine("The order is valid!");
            }
            else
            {
                ErrorSummary summary = runner.GetErrorSummary(order);
                foreach (var invalidProperty in summary.InvalidProperties)
                {
                    Console.WriteLine("{0} is invalid because:", invalidProperty);
                    foreach (var error in summary.GetErrorsForProperty(invalidProperty))
                    {
                        Console.WriteLine("\t * {0}", error);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
