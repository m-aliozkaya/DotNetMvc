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
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.About).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz");
            RuleFor(x => x.About).Must(w => w.Contains("a")).When(x => !string.IsNullOrEmpty(x.About)).WithMessage("About kesinlikle 'A' harfi içermeli");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.SurName).MaximumLength(20).WithMessage("Lütfen 50 karakter üstünde değer girmeyin");
        }
    }
}
