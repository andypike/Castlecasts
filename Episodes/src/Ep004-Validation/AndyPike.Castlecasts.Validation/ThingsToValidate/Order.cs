using Castle.Components.Validator;

namespace AndyPike.Castlecasts.Validation.ThingsToValidate
{
    public class Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        [ValidateSelf]
        public void Validate(ErrorSummary errors)
        {
            if (Product == null)
            {
                errors.RegisterErrorMessage("Product", "The order must have a product.");
                return;
            }

            if (Quantity < Product.MinQuantity || Quantity > Product.MaxQuantity)
                errors.RegisterErrorMessage("Quantity", string.Format("The quantity {0} is invalid, it must be between {1} and {2}", Quantity, Product.MinQuantity, Product.MaxQuantity));
        }

    }

    public class Product
    {
        public string Name { get; set; }
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }
    }
}