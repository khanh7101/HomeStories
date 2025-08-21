using Microsoft.EntityFrameworkCore;
using StoriesWebAPI.Domain.Entities;
using StoriesWebAPI.Infrastructure.Data;


namespace StoriesWebAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Entity classes theo convention số ít
        public DbSet<User> Users => Set<User>();
        public DbSet<Story> Stories => Set<Story>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<StoryGenre> StoryGenres => Set<StoryGenre>();
        public DbSet<ContributorFollow> ContributorFollows => Set<ContributorFollow>();
        public DbSet<StoryFollow> StoryFollows => Set<StoryFollow>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Áp dụng Fluent API từ các lớp cấu hình riêng
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // Ví dụ nếu muốn composite key trực tiếp (nếu chưa có cấu hình riêng)
            // modelBuilder.Entity<StoryGenre>()
            //     .HasKey(sg => new { sg.StoryId, sg.GenreId });

            // modelBuilder.Entity<ContributorFollow>()
            //     .HasKey(cf => new { cf.FollowerId, cf.FolloweeId });

            // modelBuilder.Entity<StoryFollow>()
            //     .HasKey(sf => new { sf.UserId, sf.StoryId });
        }
    }
}
