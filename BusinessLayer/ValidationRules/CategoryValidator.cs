using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adi bos gecilemez")
                .MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz")
                .MinimumLength(2).WithMessage("En az 2 karakter giriniz");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Aciklama kismi bos gecilemez");
        }
    }
}
