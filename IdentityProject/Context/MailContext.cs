using IdentityProject.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityProject.Context
{
    public class MailContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-90M90HO\\SQLEXPRESS;initial Catalog=IdentityProjectDb;integrated Security=true;trust server certificate=true");
        }
        public DbSet<Message> Messages { get; set; }
    }
}
