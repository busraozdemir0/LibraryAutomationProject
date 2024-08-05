using FluentValidation.Attributes;
using LibraryAutomation.Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Model
{
    [Validator(typeof(BookRegistrationMovementsValidator))]

    public class BookRegistrationMovements // Kitap kayit hareketleri
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Transaction { get; set; }
        public string Explanation { get; set; }
        public DateTime CreatedDate { get; set; }
        public Book Book { get; set; }
    }
}
