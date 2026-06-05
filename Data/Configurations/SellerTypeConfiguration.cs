using B2B.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2B.Data.Configurations
{
    public class SellerTypeConfiguration : IEntityTypeConfiguration<SellerType>
    {
        public void Configure(EntityTypeBuilder<SellerType> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(s => s.Description)
                   .HasMaxLength(500);

            // Note: The relationship mapping here is already handled on the Business side 
            // via .HasOne(b => b.SellerType).WithMany(s => s.Businesses)
        }
    }
}
