using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OnlineCourseProvider.Data;
using OnlineCourseProvider.Models;
using OnlineCourseProvider.Repositories;
using OnlineCourseProvider.Services;
using System.Text.Json.Serialization;

namespace OnlineCourseProvider
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository<Course>, CourseRepository>();
            services.AddScoped<ICourseService, CourseService>();
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            // Add logger service configuration here
        }

        public static void ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(configuration["Swagger:Version"], new OpenApiInfo
                {
                    Title = configuration["Swagger:ApiName"],
                    Version = configuration["Swagger:Version"],
                    Description = configuration["Swagger:Description"],
                });
            });
            services.AddSwaggerGen();
        }

        public static void ConfigureControllers(this IServiceCollection services)
        {
            //services.AddControllers();
            services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        }

        public static void ConfigureErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }

        // Configure services method
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureLoggerService(services);
            ConfigureDbContext(services, configuration);
            ConfigureRepositories(services, configuration);
            ConfigureSwagger(services, configuration);
            ConfigureControllers(services);

        }
    }

}
