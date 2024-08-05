using FluentValidation.Attributes;
using LibraryAutomation.Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Model
{
    [Validator(typeof(AboutValidator))] // Hakkimizda tablosuna ait AboutValidator validasyonunun calismasi icin
    public class About
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Explanation { get; set; }
    }
}
