using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Model
{
    public class BookMovements // Kitap hareketleri tablosu
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public string Transaction { get; set; } // Yapilan islem
        public DateTime CreatedDate { get; set; } // Yapilan islem
    }
}
