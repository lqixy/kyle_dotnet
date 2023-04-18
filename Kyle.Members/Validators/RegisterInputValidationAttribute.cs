using System.ComponentModel.DataAnnotations;
using Kyle.Members.ViewModels;

namespace Kyle.Members.Validators;

[AttributeUsage(AttributeTargets.Class)]
public class RegisterInputValidationAttribute: ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var result = ValidationResult.Success;
        var input = value as RegisterInput;
        if (string.IsNullOrWhiteSpace(input.Email)
            && string.IsNullOrWhiteSpace(input.Mobile)
            && string.IsNullOrWhiteSpace(input.Account))
        {
            result = new ValidationResult("邮箱/用户名/手机号至少填写一种");
        }

        return result;
    }
}