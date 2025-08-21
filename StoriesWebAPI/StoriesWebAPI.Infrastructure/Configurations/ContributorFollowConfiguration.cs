using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoriesWebAPI.Domain.Entities;

namespace StoriesWebAPI.Infrastructure.Configurations
{
    public class ContributorFollowConfiguration : IEntityTypeConfiguration<ContributorFollow>
    {
        public void Configure(EntityTypeBuilder<ContributorFollow> builder)
        {
            // Composite key: tránh duplicate
            builder.HasKey(cf => new { cf.UserId, cf.ContributorId });

            // Quan hệ User -> FollowingContributors
            builder.HasOne(cf => cf.User)
                   .WithMany(u => u.FollowingContributors)
                   .HasForeignKey(cf => cf.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Quan hệ Contributor -> Followers
            builder.HasOne(cf => cf.Contributor)
                   .WithMany(u => u.Followers)
                   .HasForeignKey(cf => cf.ContributorId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(cf => cf.FollowedAt)
                   .IsRequired()
                   .HasDefaultValueSql("UTC_TIMESTAMP()");
        }
    }
}