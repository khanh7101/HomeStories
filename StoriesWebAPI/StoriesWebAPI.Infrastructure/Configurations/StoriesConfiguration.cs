using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoriesWebAPI.Domain.Entities;

namespace StoriesWebAPI.Infrastructure.Configurations
{
    public class StoriesConfiguration : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> entity)
        {
            // Title: nvarchar(200), NOT NULL, UNIQUE
            entity.Property(s => s.Title)
                .HasColumnType("nvarchar(200)")
                .IsRequired();

            // ContributorId: FK liên kết User
            entity.HasOne(c => c.Contributor)
                      .WithMany()
                      .HasForeignKey(c => c.ContributorId)
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            // Description: nvarchar(MAX), NULL
            entity.Property(s => s.Description)
                .HasColumnType("nvarchar(max)");

            // CoverUrl: nvarchar(255), NULL
            entity.Property(s => s.CoverUrl)
                .HasColumnType("varchar(300)");

            // FollowersCount: int, NULL, default 0
            entity.Property(c => c.FollowersCount)
                      .HasDefaultValue(0);

            // AverageRate: decimal(3,2), NOT NULL, default 0.0
            entity.Property(c => c.AverageRate)
                  .HasColumnType("decimal(2,1)")
                  .HasDefaultValue(0.0M);


            // CreatedAt: datetime, NOT NULL
            entity.Property(c => c.CreatedAt)
                  .HasColumnType("datetime")
                  .IsRequired();

            // UpdatedAt: timestamp, auto update, NOT NULL
            entity.Property(c => c.UpdatedAt)
                  .HasColumnType("timestamp")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP")
                  .ValueGeneratedOnAddOrUpdate()
                  .IsRequired();

        }
    }
}
