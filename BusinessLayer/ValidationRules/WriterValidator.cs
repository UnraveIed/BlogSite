using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adi soyadi kismi bos gecilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail adresi bos gecilemez");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lutfen gecerli bir mail adresi giriniz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Sifre bos gecilemez");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lutfen en az 2 karakter girisi yapiniz");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Lutfen en fazla 50 karakter giriniz");
        }
    }
}
