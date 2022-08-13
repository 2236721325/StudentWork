using FluentValidation;

namespace User_DLL.Models.Extensions
{
    public class CheckRecordValidator : AbstractValidator<CheckRecord>
    {
        public CheckRecordValidator()
        {
            RuleFor(t => t.Name).MaximumLength(12);
        }
    }
}
