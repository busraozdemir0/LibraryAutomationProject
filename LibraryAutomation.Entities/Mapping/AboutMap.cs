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
    public class AboutMap : EntityTypeConfiguration<About>
    {
        public AboutMap()
        {
            this.HasKey(x => x.Id); // Primary Key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Otomatik artan sayi
            this.Property(x => x.Content).IsRequired().HasMaxLength(500);
            this.Property(x => x.Explanation).HasMaxLength(5000); // Aciklama alani bos gecilebilir
        }
    }
}
