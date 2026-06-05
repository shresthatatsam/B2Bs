using B2B.Entities;
using B2B.Entities.Product;
using B2B.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        public DbSet<Business> Businesses { get; set; }
        public DbSet<SellerType> SellerTypes { get; set; }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                Description = "System Admin"
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Seller",
                Description = "Business/Seller user"
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Buyer",
                Description = "Normal customer"
            }
                );

            // This single line scans your entire assembly (project) and applies 
            // the UserConfiguration class (and any future configuration files you add)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }


}
