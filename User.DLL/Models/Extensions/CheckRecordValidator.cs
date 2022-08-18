using FluentValidation;

namespace User_DLL.Models.Extensions
{
    public class CheckRecordValidator : AbstractValidator<CheckRecord>
    {
        public CheckRecordValidator()
        {
            RuleFor(t => t.Name).MaximumLength(12);
            RuleFor(t => t.IDCard).MaximumLength(18);
        }
    }
}
