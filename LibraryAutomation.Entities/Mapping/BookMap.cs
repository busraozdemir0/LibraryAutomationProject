using LibraryAutomation.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Mapping
{
    public class BookMap:EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            this.HasKey(x => x.Id); // Primary Key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Otomatik artan sayi
            this.Property(x => x.BarcodeNo).IsRequired().HasMaxLength(30);
            this.Property(x => x.BookName).IsRequired().HasMaxLength(100);
            this.Property(x => x.WriterName).IsRequired().HasMaxLength(100);
            this.Property(x => x.Publisher).IsRequired().HasMaxLength(150);
            this.Property(x => x.Explanation).HasMaxLength(5000);

        }
    }
}
