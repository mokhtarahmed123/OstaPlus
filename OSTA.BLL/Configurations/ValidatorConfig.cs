using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
namespace OSTA.BLL.Configurations
{
    public static class ValidatorConfig
    {
        public static IServiceCollection AddValidatorConfig(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }

    }
}
