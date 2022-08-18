using FluentValidation;

namespace User_DLL.Models.Extensions
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(t => t.UserName).MaximumLength(36);
            RuleFor(t => t.Name).MaximumLength(36);
            RuleFor(t => t.UserPwd).MaximumLength(32);
            RuleFor(t => t.PhoneNumber).MaximumLength(11);
            RuleFor(t => t.AddressDetail).MaximumLength(128);
            RuleFor(t => t.Remarks).MaximumLength(128);
            RuleFor(t => t.CurrentUnit).MaximumLength(32);
            RuleFor(t => t.IDCard).MaximumLength(18);
            RuleFor(t => t.AddressDetail).MaximumLength(128);

        }
    }
}
