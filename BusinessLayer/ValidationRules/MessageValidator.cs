using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Kategori Adını Boş Bırakamazsınız;");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Açıklama Alanının Boş Bırakamazsınız");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Açıklama Alanının Boş Bırakamazsınız");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen 3 karakterden fazla giriniz");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla giriş yapmayınız");

        }

    }
}
