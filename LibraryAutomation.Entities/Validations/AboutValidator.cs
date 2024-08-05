using FluentValidation;
using LibraryAutomation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Validations
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("İçerik alanı boş geçilemez.");

            RuleFor(x => x.Content)
                .MaximumLength(500)
                .WithMessage("İçerik alanı en fazla 500 karakter olabilir.");
        }
    }
}
