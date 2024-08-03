using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Model
{
    public class UserMovements
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Explanation { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
    }
}
