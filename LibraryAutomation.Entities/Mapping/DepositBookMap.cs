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
    public class DepositBookMap : EntityTypeConfiguration<DepositBook>
    {
        public DepositBookMap()
        {
            this.HasKey(x => x.Id); // Primary Key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Otomatik artan sayi

            // Kitap ile Emanet kitap tablosu arasinda bire cok iliski
            this.HasRequired(x => x.Book).WithMany(x => x.DepositBooks).HasForeignKey(x => x.BookId);
            
            // Uye ile emanet kitap tablosu arasinda bire cok iliski
            this.HasRequired(x => x.Member).WithMany(x => x.DepositBooks).HasForeignKey(x => x.MemberId);
        }
    }
}
