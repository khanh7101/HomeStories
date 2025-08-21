using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoriesWebAPI.Domain.Entities;

namespace StoriesWebAPI.Infrastructure.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> entity)
        {
            // Name: nvarchar(100), NOT NULL, UNIQUE
            entity.Property(g => g.Name)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            entity.HasIndex(g => g.Name)
                .IsUnique();
        }
    }
}
