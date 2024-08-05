using FluentValidation;
using LibraryAutomation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Validations
{
    public class BookTypesValidator:AbstractValidator<BookTypes>
    {
        public BookTypesValidator()
        {
            RuleFor(x => x.BookType)
                .MaximumLength(150)
                .WithMessage("Kitap Türü alanı en fazla 150 karakter olabilir.");

            RuleFor(x => x.BookType)
                .NotEmpty()
                .WithMessage("Kitap Türü alanı boş geçilemez.");
        }
    }
}
