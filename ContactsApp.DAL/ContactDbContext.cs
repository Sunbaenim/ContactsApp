using ContactsApp.DAL.Configurations;
using ContactsApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.DAL
{
    public class ContactDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JHP2PQQ\\TB2019;initial catalog=ContactsDB;integrated security=true;");
            //optionsBuilder.UseSqlServer("server=SONIC-05;initial catalog=ContactsDB;uid=sa;pwd=formation;");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfiguration(new ContactConfig());
            mb.ApplyConfiguration(new PhoneConfig());
        }
    }
}
