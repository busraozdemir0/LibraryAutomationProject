using FluentValidation.Attributes;
using LibraryAutomation.Entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Model
{
    [Validator(typeof(BookValidator))]

    public class Book
    {
        public int Id { get; set; }
        public string BarcodeNo { get; set; }
        public int BookTypeId { get; set; }
        public string BookName { get; set; }
        public string WriterName { get; set; }
        public string Publisher { get; set; } // Yayin evi
        public int StockCount { get; set; } 
        public int PageCount { get; set; } 
        public string Explanation { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;

        public BookTypes BookTypes { get; set; } // Tekil iliskilendirme
        public List<DepositBook> DepositBooks { get; set; }
        public List<BookMovements> BookMovements { get; set; }
        public List<BookRegistrationMovements> BookRegistrationMovements { get; set; }
    }
}
