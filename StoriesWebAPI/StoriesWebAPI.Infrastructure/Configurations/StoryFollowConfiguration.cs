using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoriesWebAPI.Domain.Entities;

namespace StoriesWebAPI.Infrastructure.Configurations
{
    public class StoryFollowConfiguration : IEntityTypeConfiguration<StoryFollow>
    {
        public void Configure(EntityTypeBuilder<StoryFollow> entity)
        {
            // Composite PK: tránh duplicate follow
            entity.HasKey(usf => new { usf.UserId, usf.StoryId });

            // UserId: FK liên kết với Users
            entity.HasOne(usf => usf.User)
                  .WithMany()
                  .HasForeignKey(usf => usf.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            // StoryId: FK liên kết với Stories
            entity.HasOne(usf => usf.Story)
                  .WithMany()
                  .HasForeignKey(usf => usf.StoryId)
                  .OnDelete(DeleteBehavior.Cascade);

            // CreatedAt: DATETIME, NOT NULL
            entity.Property(u => u.FollowedAt)
                  .HasColumnType("datetime")
                  .IsRequired();
        }
    }
}
