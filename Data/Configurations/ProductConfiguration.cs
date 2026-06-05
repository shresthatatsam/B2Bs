using B2B.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2B.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Description)
                   .HasMaxLength(2000);

            // Crucial: Forces database decimal precision for pricing (e.g., 999999.99)
            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.Stock)
                   .HasDefaultValue(0);

            builder.Property(p => p.Status)
                   .IsRequired()
                   .HasMaxLength(30)
                   .HasDefaultValue("Draft"); // e.g., Active, Draft, OutOfStock

            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            // Relationship: One Business can have many Products
            builder.HasOne(p => p.Business)
                   .WithMany() // Add ICollection<Product> inside Business if you want to link the other way later
                   .HasForeignKey(p => p.BusinessId)
                   .OnDelete(DeleteBehavior.Cascade); // Deleting a business removes its products

            // Relationship: One Category can have many Products
            builder.HasOne(p => p.Category)
                   .WithMany() // Add ICollection<Product> inside Category if needed
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict); // Block category deletion if it contains items
        }
    }
}
