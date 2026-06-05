namespace B2B.Data.Seed
{
    public class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            await RoleSeeder.SeedRolesAsync(context);
        }
    }
}
