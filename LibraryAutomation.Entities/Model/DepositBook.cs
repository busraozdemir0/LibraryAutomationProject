using FluentValidation.Attributes;
using LibraryAutomation.Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Model
{
    [Validator(typeof(DepositBookValidator))]
    public class DepositBook // Emanet Kitap tablosu
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public int BookCount { get; set; }
        public DateTime ReceivedDateBook { get; set; } // Kitabi aldigi tarih
        public DateTime DeliveryDateBook { get; set; } // Kitabi iade tarihi

        public Book Book { get; set; }
        public Member Member { get; set; }
    }
}
