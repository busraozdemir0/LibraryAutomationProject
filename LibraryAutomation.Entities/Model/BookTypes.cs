using FluentValidation.Attributes;
using LibraryAutomation.Entities.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Model
{
    [Validator(typeof(BookTypesValidator))]

    public class BookTypes // Kitap Türleri tablosu
    {
        public int Id { get; set; }
        public string BookType { get; set; }
        public string Explanation { get; set; }
        public List<Book> Books { get; set; } // Cogul iliskilendirme
    }
}
