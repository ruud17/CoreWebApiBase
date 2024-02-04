using CoreWebApiBase.Domain.Data;
using CoreWebApiBase.Domain.Interfaces;
using CoreWebApiBase.Domain.Repositories;
using CoreWebApiBase.Services.Interfaces;
using CoreWebApiBase.Services.Logger;
using CoreWebApiBase.Services.Services;

namespace CoreWebApiBase.API.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddSingleton<ILoggerService, LoggerService>();

            return services;
        }
    }
}