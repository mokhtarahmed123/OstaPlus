using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OSTA.BLL.DTOs.AuthDTOs;
using OSTA.BLL.DTOs.CategoryDTOS;
using OSTA.BLL.DTOs.RoleDTOs;
using OSTA.BLL.DTOs.ServiceDTOs;
using OSTA.BLL.DTOs.StoreDTOs;
using OSTA.BLL.FluentValidation.AuthValidation;
using OSTA.BLL.FluentValidation.CategoryValidation;
using OSTA.BLL.FluentValidation.RoleValidation;
using OSTA.BLL.FluentValidation.ServiceValidation;
using OSTA.BLL.FluentValidation.StoreValidation;
using OSTA.BLL.Interfaces;
using OSTA.BLL.Services;

namespace OSTA.DAL.Configurations
{
    public static class DependencyInjectionServices
    {
        public static IServiceCollection AddServicesDependenceis(this IServiceCollection services)
        {
            // Add  
            //  services.AddScoped    => Services  
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IValidator<AddCategory>, AddCategoryValidator>();
            services.AddScoped<IValidator<AddCategory>, AddCategoryValidator>();
            services.AddScoped<IValidator<EditCategory>, EditCategoryValidation>();
            services.AddScoped<IValidator<CreateRoleDto>, AddRoleValidation>();
            services.AddScoped<IValidator<EditRoleDto>, EditRoleValidation>();
            services.AddScoped<IValidator<SignUpUser>, SignUpValidation>();
            services.AddScoped<IValidator<UpdateUserDTO>, UpdateUserValidation>();
            services.AddScoped<IValidator<AddServiceDTO>, AddServiceValidation>();
            services.AddScoped<IValidator<AddStoreDTO>, AddStoreValidation>();
            services.AddScoped<IValidator<UpdateServiceDTO>, UpdateServiceValidation>();
            return services;
        }
    }
}
