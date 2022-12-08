using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class WriterValidationRules:AbstractValidator<Writer>
	{

		public WriterValidationRules()
		{
			RuleFor(w => w.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez.");
			RuleFor(w => w.WriterName).MinimumLength(2).WithMessage("Adınız en az iki karakter olmalıdır");
			RuleFor(w => w.WriterName).MaximumLength(10).WithMessage("Adınız maximum 10 karakter olabilir");
			RuleFor(w => w.WriterMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez");
			RuleFor(w => w.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez");
			RuleFor(w => w.WriterPassword).Must(PasswordRules).WithMessage("Kurallara Uyunuz.");
		}

		public static bool PasswordRules(string arg)
		{
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

			if(!hasNumber.IsMatch(arg) || !hasUpperChar.IsMatch(arg) || !hasLowerChar.IsMatch(arg) || !hasSymbols.IsMatch(arg))
			{
				return false;
			}
			return true;
        }
	}
}
