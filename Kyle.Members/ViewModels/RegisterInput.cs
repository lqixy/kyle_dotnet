using System.ComponentModel.DataAnnotations;
using Kyle.Members.Validators;

namespace Kyle.Members.ViewModels;

[RegisterInputValidation]
public class RegisterInput
{
    public string? Account { get; set; }

    // public string Name { get; set; }

    [MinLength(8,ErrorMessage = "密码不能低于8位"),
    Required]
    public string Password { get; set; }

    [EmailAddress(ErrorMessage = "Email地址不正确")]
    public string? Email { get; set; }
    
    [Phone(ErrorMessage = "手机号码不正确")]
    public string? Mobile { get; set; }
}