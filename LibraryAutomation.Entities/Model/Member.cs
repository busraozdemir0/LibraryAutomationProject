using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Model
{
    public class Member
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public int NumberOfBooksRead { get; set; } // Okunan kitap sayisi
        public DateTime CreatedDate { get; set; }
        public List<DepositBook> DepositBooks { get; set; }
    }
}
