using FluentValidation;
using LibraryAutomation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Validations
{
    public class MemberValidator:AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email alanı boş geçilemez.");

            RuleFor(x => x.Email)
                .MaximumLength(150)
                .WithMessage("Email alanı en fazla 150 karakter olabilir.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Lütfen bir mail adresi formatı giriniz.");

            RuleFor(x => x.NameSurname)
                .NotEmpty()
                .WithMessage("Adı Soyadı alanı boş geçilemez.");

            RuleFor(x => x.NameSurname)
                .MaximumLength(100)
                .WithMessage("Adı Soyadı alanı en fazla 100 karakter olabilir.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Telefon alanı boş geçilemez.");

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(11)
                .WithMessage("Telefon alanı en fazla 11 karakter olabilir.");

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Adres alanı boş geçilemez.");

            RuleFor(x => x.Address)
                .MaximumLength(500)
                .WithMessage("Adres alanı en fazla 500 karakter olabilir.");
        }
    }
}
