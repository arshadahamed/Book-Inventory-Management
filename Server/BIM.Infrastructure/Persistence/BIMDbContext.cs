using BIM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BIM.Infrastructure.Persistence;

internal class BIMDbContext(DbContextOptions<BIMDbContext> options) : DbContext(options)
{
    internal DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}