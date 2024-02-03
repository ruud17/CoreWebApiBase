using CoreWebApiBase.Domain.Data;
using CoreWebApiBase.Domain.Interfaces;
using CoreWebApiBase.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApiBase.API.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}