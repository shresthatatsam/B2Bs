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

            // Relationship: One Business can have many Products
            builder.HasOne(p => p.Business)
                   .WithMany() // Add ICollection<Product> inside Business if you want to link the other way later
                   .HasForeignKey(p => p.BusinessId)
                   .IsRequired(false);

            // 3. Uniqueness Constraints
            // Prevents business managers from making duplicate categories
            builder.HasIndex(c => c.Name)
                   .IsUnique();
        }
    }
}
