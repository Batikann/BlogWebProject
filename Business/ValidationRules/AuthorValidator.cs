using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Yazar Soyadı Boş Geçilemez.");
            RuleFor(x => x.AuthorPassword).NotEmpty().WithMessage("Yazar Şifresi Boş Geçilemez.");
            RuleFor(x => x.AuthorMail).NotEmpty().NotEmpty().WithMessage("Yazar Maili Boş Geçilemez.");
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(2).WithMessage("Lütfen 2 Karakterden Kısa İsim Girmeyiniz.");
            RuleFor(x => x.AuthorPassword).Must(isPasswordValid)
                .WithMessage("Parolanız da en az bir küçük harf bir büyük harf ve rakam olmalıdır.");
        }
        private bool isPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return regex.IsMatch(arg);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
