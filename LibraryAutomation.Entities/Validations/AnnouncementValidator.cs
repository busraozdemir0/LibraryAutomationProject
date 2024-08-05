using FluentValidation;
using LibraryAutomation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Validations
{
    public class AnnouncementValidator:AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Başlık alanı boş geçilemez.");

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("İçerik alanı boş geçilemez.");

            RuleFor(x => x.CreatedDate)
                .NotEmpty()
                .WithMessage("Tarih alanı boş geçilemez.");

            RuleFor(x => x.Title)
                .Length(5, 150).WithMessage("Başlık alanı 5-150 karakter arasında olmalıdır.");

            RuleFor(x => x.Content)
                .MaximumLength(500).WithMessage("Duyuru alanı en fazla 500 karakter olmalıdır.");
        }
    }
}
