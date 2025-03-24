using System.ComponentModel.DataAnnotations;

namespace InputValidationApi.Validators
{
    public class NoWhiteSpaceAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is string str && !string.IsNullOrWhiteSpace(str);
        }
    }
}
