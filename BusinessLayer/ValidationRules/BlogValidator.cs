using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Blog basligini bos gecemezsiniz");
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Blog icerigi bos gecilemez");
            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Blog gorseli bos gecilemez");
            RuleFor(x => x.Title)
                .MinimumLength(2).WithMessage("En az 2 karakter giriniz")
                .MaximumLength(50).WithMessage("En fazla 50 karakter giriniz");
        }
    }
}
