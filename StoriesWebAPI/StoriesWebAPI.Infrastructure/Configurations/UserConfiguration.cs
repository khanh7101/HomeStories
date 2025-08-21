using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoriesWebAPI.Domain.Entities;

namespace StoriesWebAPI.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            // Username: nvarchar(50), NOT NULL, UNIQUE
            entity.Property(u => u.Username)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            entity.HasIndex(u => u.Username).IsUnique();

            // Email: varchar(100), UNIQUE NOT NULL
            entity.Property(u => u.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            entity.HasIndex(u => u.Email).IsUnique();

            // Password: nvarchar(50), NOT NULL
            entity.Property(u => u.Password)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            // CreatedAt: DATETIME, NOT NULL
            entity.Property(u => u.CreatedAt)
                .HasColumnType("datetime")
                .IsRequired();

            // UpdatedAt: TIMESTAMP, auto update,NOT NULL
            entity.Property(u => u.UpdatedAt)
                  .HasColumnType("timestamp")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP")
                  .ValueGeneratedOnAddOrUpdate()
                  .IsRequired();
        }
    }
}
