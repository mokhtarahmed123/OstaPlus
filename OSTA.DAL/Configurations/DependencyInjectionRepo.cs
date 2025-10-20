using CBS.Infrastructure.Bases;
using Microsoft.Extensions.DependencyInjection;
using OSTA.DAL.Interfaces;
using OSTA.DAL.Repositories;

namespace OSTA.DAL.Configurations
{
    public static class DependencyInjectionRepo
    {
        public static IServiceCollection AddRepoDependencies(this IServiceCollection services) //Extension Method 
        {
            // Add 
            //  services.AddScoped    => Repo
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            return services;
        }

    }
}
