using Microsoft.Extensions.DependencyInjection;

namespace GestaoPatrimonial.IoC
{
    public static class DependencyInjectionCors
    {
        public static IServiceCollection AddInfrastructureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });

            return services;
        }
    }
}
