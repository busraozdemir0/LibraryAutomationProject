﻿using FluentValidation;
using LibraryAutomation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Validations
{
    public class BookRegistrationMovementsValidator:AbstractValidator<BookRegistrationMovements>
    {
        public BookRegistrationMovementsValidator()
        {
            RuleFor(x => x.Transaction)
                .MaximumLength(150)
                .WithMessage("Yapılan İşlem alanı en fazla 150 karakter olabilir.");
        }
    }
}