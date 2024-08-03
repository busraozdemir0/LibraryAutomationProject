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
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(x => x.Id); // Primary Key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Otomatik artan sayi
            this.Property(x => x.UserName).IsRequired().HasMaxLength(30);
            this.Property(x => x.Password).IsRequired().HasMaxLength(15);
            this.Property(x => x.NameSurname).IsRequired().HasMaxLength(100);
            this.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(11);
            this.Property(x => x.Address).HasMaxLength(500);
            this.Property(x => x.Email).HasMaxLength(150);
        }
    }
}
