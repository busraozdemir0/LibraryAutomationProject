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
    public class BookRegistrationMovementsMap : EntityTypeConfiguration<BookRegistrationMovements>
    {
        public BookRegistrationMovementsMap()
        {
            this.HasKey(x => x.Id); // Primary Key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Otomatik artan sayi
            this.Property(x => x.Transaction).IsRequired().HasMaxLength(150);
            this.Property(x => x.Explanation).HasMaxLength(5000);

            // Kitap ile kitap kayit hareketleri tablosu arasinda iliski
            this.HasRequired(x => x.Book).WithMany(x => x.BookRegistrationMovements).HasForeignKey(x => x.BookId);
        }
    }
}
