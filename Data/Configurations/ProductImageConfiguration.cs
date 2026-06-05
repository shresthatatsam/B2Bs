using B2B.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2B.Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            // 1. Primary Key
            builder.HasKey(pi => pi.Id);

            // 2. Property Constraints
            builder.Property(pi => pi.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(500); // Plenty of room for local storage file paths or cloud URLs (AWS S3/Cloudinary)

            // 3. Relationship (One-to-Many)
            // One Product can have many ProductImages
            builder.HasOne<Product>() // We can pass Product here even if ProductImage doesn't have a virtual Product property
                   .WithMany()        // Leave empty if Product entity doesn't have a List<ProductImage> property
                   .HasForeignKey(pi => pi.ProductId)
                   .OnDelete(DeleteBehavior.Cascade); // CRITICAL: If a product is deleted, delete its images too!
        }
    }
}
