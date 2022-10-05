using Entities;
using FluentValidation;

namespace Business.FluentValidations
{
    public class FluentCustomers: AbstractValidator<Customers>
    {
        public FluentCustomers()
        {
            RuleFor(x => x.NameSurname).MinimumLength(1).WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.NameSurname).MaximumLength(100).WithMessage("Maximum 100 Karakter Girilebilir");

            RuleFor(x => x.Email).MinimumLength(1).WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("Maximum 50 Karakter Girilebilir");

            RuleFor(x => x.Phone).MinimumLength(1).WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.Phone).MaximumLength(100).WithMessage("Maximum 20 Karakter Girilebilir");

            RuleFor(x => x.Password).MinimumLength(1).WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.Password).MaximumLength(100).WithMessage("Maximum 20 Karakter Girilebilir");
        }
    }
}
