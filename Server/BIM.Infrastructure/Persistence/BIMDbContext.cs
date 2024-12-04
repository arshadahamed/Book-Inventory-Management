using BIM.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BIM.Infrastructure.Persistence
{
    public class BIMDbContext(DbContextOptions<BIMDbContext> options) : IdentityDbContext<IdentityUser>(options)
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
               .Property(b => b.Price)
               .HasColumnType("decimal(18,2)");
        }
    }
}
