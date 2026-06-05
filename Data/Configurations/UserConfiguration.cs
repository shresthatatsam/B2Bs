using B2B.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2B.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // 1. Primary Key Configuration
            builder.HasKey(u => u.Id);

            // 2. Property Validations & Length Constraints
            builder.Property(u => u.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(500); // Hashes (like BCrypt or Identity) need a healthy buffer

            // 4. Default Values
            // Let the database generate the creation timestamp automatically on insert
            builder.Property(u => u.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()"); // Use "NOW()" if using PostgreSQL

            // 5. Performance Indexes & Uniqueness Constraints
            // Ensures two accounts can never be registered with the exact same email
            builder.HasIndex(u => u.Email)
                   .IsUnique();
        }
    }
}
