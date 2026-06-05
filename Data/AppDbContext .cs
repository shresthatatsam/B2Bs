using B2B.Entities;
using B2B.Entities.Product;
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

        public DbSet<Business> Businesses { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<SellerType> SellerTypes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // This single line scans your entire assembly (project) and applies 
            // the UserConfiguration class (and any future configuration files you add)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }


}
