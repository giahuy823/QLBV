using Microsoft.AspNetCore.Identity;
using QLBV.Models.User_Model;

public class CustomUserValidator : UserValidator<ApplicationUser>
{
    public CustomUserValidator(IdentityErrorDescriber errors) : base(errors) { }

    public override async Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user)
    {
        var errors = new List<IdentityError>();

        if (string.IsNullOrWhiteSpace(user.UserName))
        {
            errors.Add(new IdentityError
            {
                Code = "UserNameIsEmpty",
                Description = "Tên đăng nhập không được để trống."
            });
        }

       
        if (user.UserName.Length < 8)
        {
            errors.Add(new IdentityError
            {
                Code = "UserNameTooShort",
                Description = "Tên đăng nhập phải có ít nhất 8 ký tự."
            });
        }

        return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
    }
}
