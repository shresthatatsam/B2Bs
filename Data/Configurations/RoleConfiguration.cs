using B2B.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2B.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // TABLE NAME
            builder.ToTable("Roles");

            // PRIMARY KEY
            builder.HasKey(r => r.Id);

            // NAME (required + unique)
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(r => r.Name)
                .IsUnique();

            // DESCRIPTION (optional)
            builder.Property(r => r.Description)
                .HasMaxLength(200);

            // RELATIONSHIP (Role → Users)
            builder.HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
   }
