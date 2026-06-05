using B2B.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2B.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // 1. Primary Key
            builder.HasKey(c => c.Id);

            // 2. Property Constraints
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(75);

            // 3. Uniqueness Constraints
            // Prevents business managers from making duplicate categories
            builder.HasIndex(c => c.Name)
                   .IsUnique();
        }
    }
}
