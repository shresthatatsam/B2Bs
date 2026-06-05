using B2B.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Seed
{
    public class RoleSeeder
    {
        public static async Task SeedRolesAsync(AppDbContext context)
        {
            if (await context.Roles.AnyAsync())
                return; // already seeded

            var roles = new List<Role>
            {
                new Role
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Admin",
                    Description = "System Admin"
                },
                new Role
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Seller",
                    Description = "Business/Seller user"
                },
                new Role
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Buyer",
                    Description = "Normal customer"
                }
            };

            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();
        }
    }
}
