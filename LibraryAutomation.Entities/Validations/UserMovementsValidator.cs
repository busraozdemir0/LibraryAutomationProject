using FluentValidation;
using LibraryAutomation.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Validations
{
    public class UserMovementsValidator:AbstractValidator<UserMovements>
    {
        public UserMovementsValidator()
        {
            
        }
    }
}
