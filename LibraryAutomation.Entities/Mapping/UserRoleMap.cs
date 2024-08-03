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
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            this.HasKey(x => x.Id); // Primary Key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // Otomatik artan sayi

            // Kullanici ile kullanici tablosu arasindaki bire cok iliski
            this.HasRequired(x => x.User).WithMany(x => x.UserRoles).HasForeignKey(x => x.UserId);
           
            // Rol ile kullanici rolleri arasindaki bire cok iliski
            this.HasRequired(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);
        }
    }
}
