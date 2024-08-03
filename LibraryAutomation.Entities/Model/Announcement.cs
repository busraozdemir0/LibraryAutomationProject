﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Model
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Explanation { get; set; } // Aciklama
        public DateTime CreatedDate { get; set; }
    }
}
