using Entities;
using FluentValidation;

namespace Business.FluentValidations
{
    public class FluentCategories: AbstractValidator<Categories>
    {
        public FluentCategories()
        {
            RuleFor(x=> x.Name).MinimumLength(3).WithMessage("Minimum 3 Karakter Girebilirsiniz");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Maximum 50 Karakter Girebilirsiniz");
        }
    }
}
