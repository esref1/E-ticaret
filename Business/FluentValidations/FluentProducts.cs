using Entities;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.FluentValidations
{
    public class FluentProducts : AbstractValidator<Products>
    {
        public FluentProducts()
        {
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("Boş Bırakılamaz").MaximumLength(100).WithMessage("Maximum 100 Karakter Girilebilir.");

            RuleFor(x => x.Explanation).MinimumLength(1).WithMessage("Boş Bırakılamaz");

            RuleFor(x => x.Price).Must(SayiKontrol).WithMessage("Minimum 100 ve Maximum 999999 Arasında Para Birimi Girilebilir.").When(x => x.Price < 1).WithMessage("Minimum 1 ve Maximumum 999999 Arasında Stok Girelebilir.");

            RuleFor(x => x.Stock).Must(StokKontrol).WithMessage("Minimum 1 ve Maximumum 999 Arasında Stok Girelebilir.").When(x => x.Stock < 1).WithMessage("Minimum 1 ve Maximumum 999 Arasında Stok Girelebilir.");
        }

        // Regex( Regular Expression ) Nedir ?
        // Kullanıcının Girdiği değerleri C# tarafında belli kriterlere göre kontrol etmemizi sağlayan bir algoritma tarzıdır.
        // Doğrulamalar : Belirtilen Harf veya sayı ile başladığını kontrol etme, Girilen Data'nin sadece harf olması veya sadece sayı olması gibi.

        private bool SayiKontrol(decimal price)
        {
            // Girilen veri Kesinlikle Sayı olmadı ve Maximum 6 haneli olmalıdır.
            Regex regex = new Regex(@"\d{6}");
            return regex.IsMatch(price.ToString());
        }
        private bool StokKontrol(int price)
        {
            // Girilen veri Kesinlikle Sayı olmadı ve Maximum 6 haneli olmalıdır.
            Regex regex = new Regex(@"\d{6}");
            return regex.IsMatch(price.ToString());
        }
    }
}
