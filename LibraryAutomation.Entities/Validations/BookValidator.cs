using FluentValidation;
using LibraryAutomation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Validations
{
    public class BookValidator:AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.BarcodeNo)
                .MaximumLength(30)
                .WithMessage("Barkod No alanı en fazla 30 karakter olabilir.");

            RuleFor(x => x.BarcodeNo)
                .NotEmpty()
                .WithMessage("Barkod No alanı boş geçilemez.");

            RuleFor(x => x.BookName)
                .MaximumLength(100)
                .WithMessage("Kitap adı alanı en fazla 100 karakter olabilir.");

            RuleFor(x => x.BookName)
                .NotEmpty()
                .WithMessage("Kitap adı alanı boş geçilemez.");

            RuleFor(x => x.WriterName)
                .MaximumLength(100)
                .WithMessage("Yazar adı alanı en fazla 100 karakter olabilir.");

            RuleFor(x => x.WriterName)
                .NotEmpty()
                .WithMessage("Yazar adı alanı boş geçilemez.");

            RuleFor(x => x.Publisher)
                .MaximumLength(150)
                .WithMessage("Yayınevi alanı en fazla 150 karakter olabilir.");

            RuleFor(x => x.Publisher)
                .NotEmpty()
                .WithMessage("Yayınevi alanı boş geçilemez.");
        }
    }
}
