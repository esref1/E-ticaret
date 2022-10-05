using Entities;
using FluentValidation;

namespace Business.FluentValidations
{
    public class FluentOrdersAddress: AbstractValidator<OrderAddress>
    {
        public FluentOrdersAddress()
        {
            RuleFor(x => x.NameSurname).MinimumLength(1).WithMessage("Boş Bırakılamaz").MaximumLength(100).WithMessage("Maximum 100 Karakter Girilebilir.");

            RuleFor(x => x.Phone).MinimumLength(1).WithMessage("Boş Bırakılamaz").MaximumLength(20).WithMessage("Maximum 20 Karakter Girilebilir.");
         
            RuleFor(x => x.City).MinimumLength(1).WithMessage("Boş Bırakılamaz").MaximumLength(50).WithMessage("Maximum 50 Karakter Girilebilir.");
           
            RuleFor(x => x.District).MinimumLength(1).WithMessage("Boş Bırakılamaz").MaximumLength(50).WithMessage("Maximum 50 Karakter Girilebilir.");

        }
    }
}
