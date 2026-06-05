using B2B.Helpers;

namespace B2B.Infrastructure.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Helpers
            services.AddScoped<JwtHelper>();

            // later you will add:
            // services.AddScoped<IProductService, ProductService>();
            // services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
