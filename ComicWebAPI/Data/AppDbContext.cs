using ComicWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicWebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Comic> Comics => Set<Comic>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ví dụ cấu hình đơn giản
            modelBuilder.Entity<Comic>(e =>
            {
                e.Property(p => p.Title).HasMaxLength(200).IsRequired();
                e.Property(p => p.Author).HasMaxLength(120).IsRequired(false);
                e.Property(p => p.CoverUrl).HasMaxLength(500);
            });
        }
    }
}
