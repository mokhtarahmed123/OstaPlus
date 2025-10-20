using Microsoft.Extensions.DependencyInjection;

namespace OSTA.DAL.Configurations
{
    public static class DependencyInjectionServices
    {
        public static IServiceCollection AddServicesDependenceis(this IServiceCollection services)
        {
            // Add 
            //  services.AddScoped    => Services
            //services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
