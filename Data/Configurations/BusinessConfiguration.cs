using B2B.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2B.Data.Configurations
{
    public class BusinessConfiguration : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.BusinessName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(b => b.Description)
                   .HasMaxLength(1000);

            builder.Property(b => b.Logo)
                   .HasMaxLength(500); // Stores the file path or URL string

            // Relationship: One User can have one (or many) Businesses
            builder.HasOne(b => b.User)
                   .WithMany() // Leave empty if User entity doesn't have a List<Business>
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.Cascade); // If a User is deleted, delete their business profile

            // Relationship: Many Businesses belong to one SellerType lookup item
            builder.HasOne(b => b.SellerType)
                   .WithMany(s => s.Businesses)
                   .HasForeignKey(b => b.SellerTypeId)
                   .OnDelete(DeleteBehavior.Restrict); // Stop deletion of a SellerType if businesses are using it
        }
    }
}
