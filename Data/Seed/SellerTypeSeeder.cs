using B2B.Entities;

namespace B2B.Data.Seed
{
    public static class SellerTypeSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (!context.SellerTypes.Any())
            {
                var sellerTypes = new List<SellerType>
            {
                new SellerType
                {
                    Id = Guid.NewGuid(),
                    Name = "Individual",
                    Description = "A single person selling products or services independently."
                },
                new SellerType
                {
                    Id = Guid.NewGuid(),
                    Name = "Business",
                    Description = "A registered business or company selling products or services."
                },
                new SellerType
                {
                    Id = Guid.NewGuid(),
                    Name = "Wholesaler",
                    Description = "A seller that distributes products in bulk to retailers or businesses."
                },
                new SellerType
                {
                    Id = Guid.NewGuid(),
                    Name = "Retailer",
                    Description = "A seller that sells products directly to customers."
                },
                new SellerType
                {
                    Id = Guid.NewGuid(),
                    Name = "Distributor",
                    Description = "A business responsible for supplying products to retailers or other businesses."
                },
                new SellerType
                {
                    Id = Guid.NewGuid(),
                    Name = "Manufacturer",
                    Description = "A company or individual that produces goods or products."
                },
                new SellerType
                {
                    Id = Guid.NewGuid(),
                    Name = "ServiceProvider",
                    Description = "A seller offering services instead of physical products."
                }
            };

                await context.SellerTypes.AddRangeAsync(sellerTypes);
                await context.SaveChangesAsync();
            }
        }
    }
}
