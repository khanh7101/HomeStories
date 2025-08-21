using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoriesWebAPI.Domain.Entities;

namespace StoriesWebAPI.Infrastructure.Configurations
{
    public class StoryGenresConfiguration : IEntityTypeConfiguration<StoryGenre>
    {
        public void Configure(EntityTypeBuilder<StoryGenre> entity)
        {
            // Composite Primary Key
            entity.HasKey(sg => new { sg.StoryId, sg.GenreId });

            // StoryId: FK liên kết Stories
            entity.HasOne(sg => sg.Story)
                  .WithMany(s => s.StoryGenres)
                  .HasForeignKey(sg => sg.StoryId)
                  .IsRequired();

            // GenreId: FK liên kết Genres
            entity.HasOne(sg => sg.Genre)
                  .WithMany(g => g.StoryGenres)
                  .HasForeignKey(sg => sg.GenreId)
                  .IsRequired();
        }
    }
}
