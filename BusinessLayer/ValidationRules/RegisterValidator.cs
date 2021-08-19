using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class RegisterValidator:AbstractValidator<Admin>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.AdminUserName).EmailAddress().WithMessage("Lütfen bir mail giriniz");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Password kısmını boş geçemezsiniz");
            RuleFor(x => x.AdminPassword).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.AdminPassword).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter değer girişi yapın");
        }
       
    }
}
