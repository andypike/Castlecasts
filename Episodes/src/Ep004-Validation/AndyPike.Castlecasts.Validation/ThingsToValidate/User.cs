using Castle.Components.Validator;

namespace AndyPike.Castlecasts.Validation.ThingsToValidate
{
    public class User
    {
        [ValidateNonEmpty]
        public string Name { get; set; }

        [ValidateEmail]
        [ValidateNonEmpty]
        public string Email { get; set; }

        [ValidateLength(6, 20)]
        public string Password { get; set; }

        [ValidateSameAs("Password")]
        public string PasswordConfirmation { get; set; }

        [ValidateRegExp("^[a-z0-9_-]{3,16}$")]
        public string UserName { get; set; }

        [ValidateGroupNotEmpty("PhoneNumbers")]
        public string MobilePhone { get; set; }

        [ValidateGroupNotEmpty("PhoneNumbers")]
        public string WorkPhone { get; set; }

        [ValidateGroupNotEmpty("PhoneNumbers")]
        public string HomePhone { get; set; }
    }
}