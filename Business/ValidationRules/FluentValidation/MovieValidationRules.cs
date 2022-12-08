using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MovieValidationRules:AbstractValidator<Movie>
    {
        public MovieValidationRules()
        {
            RuleFor(m => m.MovieName).NotEmpty().WithMessage("Film ismi boş geçilemez");
            RuleFor(m => m.MovieContent).NotEmpty().WithMessage("Film açıklaması boş geçilemez");
            RuleFor(m => m.MovieCountry).NotEmpty().WithMessage("Filmin ülkesi boş geçilemez");
            RuleFor(m => m.RunnigTime).NotEmpty().WithMessage("Film süresi boş geçilemez");
            RuleFor(m => m.MovieImage).NotEmpty().WithMessage("Film resmi boş geçilemez");
            RuleFor(m => m.MovieRate).NotEmpty().WithMessage("Film rate'i boş geçilemez");
            RuleFor(m => m.ReleaseYear).NotEmpty().WithMessage("Film yılı boş geçilemez");
            RuleFor(m => m.MovieName).MaximumLength(15).WithMessage("Film ismi max 15 karakter olabilir");
            RuleFor(m => m.MovieContent).MaximumLength(150).WithMessage("Film açıklaması max 150 karakter olabilir");
        }
    }
}
