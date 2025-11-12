using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OSTA.BLL.Configurations;
using OSTA.DAL.Configurations;
using OSTA.DAL.Context;
using OSTA.DAL.Entities;
using OSTA.PL.Middleware;


namespace OSTA.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            #region Handle Data Base
            builder.Services.AddDbContext<OstaContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("OstaPlusDataBase"));

            });
            #endregion
            #region CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policyBuilder =>
                    policyBuilder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader());
            });

            #endregion

            #region DI // From BLL
            builder.Services.AddRepoDependencies().AddServicesDependenceis().AddMappingDependenceis().AddValidatorConfig();

            #endregion
            #region HandlerMiddleware Exceptions
            builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();
            #endregion


            builder.Services.AddIdentity<ApplicationUser, RoleApplication>()
              .AddEntityFrameworkStores<OstaContext>()
          .AddDefaultTokenProviders();







            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

            app.UseCors("CorsPolicy");
            app.MapControllers();

            app.Run();
        }
    }
}
