using System;
using Castle.Components.Validator;

namespace AndyPike.Castlecasts.Validation.CustomValidators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ValidateNotNullAttribute : AbstractValidationAttribute
    {
        public override IValidator Build()
        {
            IValidator validator = new NotNullValidator();

            ConfigureValidatorMessage(validator);

            return validator;
        }
    }
}