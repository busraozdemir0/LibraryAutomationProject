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
    public class AnnouncementMap : EntityTypeConfiguration<Announcement>
    {
        public AnnouncementMap()
        {
          //  this.ToTable("Announcement"); // Tablomuz db'ye hangi isimde kaydedilsin
            this.HasKey(x => x.Id); // Primary Key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Otomatik artan sayi
            this.Property(x => x.Title).HasColumnType("varchar"); // Sütun turu
            this.Property(x => x.Title).IsRequired().HasMaxLength(150); // Title alani bos gecilemez ve en fazla 150 karakter 
            this.Property(x => x.Content).IsRequired().HasMaxLength(500);
            this.Property(x => x.Explanation).HasMaxLength(5000); // Aciklama alani bos gecilebilir

            this.Property(x => x.Id).HasColumnName("Id"); 
        }
    }
}
