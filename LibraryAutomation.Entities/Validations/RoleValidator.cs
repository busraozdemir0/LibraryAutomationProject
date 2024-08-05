using FluentValidation;
using LibraryAutomation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Validations
{
    public class RoleValidator:AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(x => x.RoleName)
                .NotEmpty()
                .WithMessage("Rol alanı boş geçilemez.");

            RuleFor(x => x.RoleName)
                .MaximumLength(50)
                .WithMessage("Rol alanı en fazla 50 karakter olabilir.");
        }
    }
}
