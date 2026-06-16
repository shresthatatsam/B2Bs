using B2B.Helpers;
using B2B.Repositories.Implementations;
using B2B.Repositories.Interfaces;
using B2B.Services.Implementations;
using B2B.Services.Interfaces;

namespace B2B.Infrastructure.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Helpers
            services.AddScoped<JwtHelper>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ISellerTypeService, SellerTypeService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBusinessService, BusinessService>();

            services.AddScoped<IUserContextService, UserContextService>();
            // later you will add:
            // services.AddScoped<IProductService, ProductService>();
            // services.AddScoped<IAuthService, AuthService>();
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
