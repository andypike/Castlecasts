using Castle.Components.Validator;

namespace AndyPike.Castlecasts.Validation.CustomValidators
{
    public class NotNullValidator : AbstractValidator
    {
        public override bool IsValid(object instance, object fieldValue)
        {
            return fieldValue != null;
        }

        public override bool SupportsBrowserValidation
        {
            get { return false; }
        }
    }
}