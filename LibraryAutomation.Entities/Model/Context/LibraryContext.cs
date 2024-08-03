using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAutomation.Entities.Model.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base()
        {

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookMovements> BookMovements { get; set; }
        public DbSet<BookRegistrationMovements> BookRegistrationMovements { get; set; }
        public DbSet<BookTypes> BookTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DepositBook> DepositBooks { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserMovements> UserMovements { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
