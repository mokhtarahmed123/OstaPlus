using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
namespace OSTA.BLL.Configurations
{
    public static class MappingConfig
    {
        public static IServiceCollection AddMappingDependenceis(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
            return services;
        }

    }
}
