using Application.Mapper;
using Application.Services;
using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration.DependencyInjection
{
    public static class ApplicationDI
    {
        public static void AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<IService<Transaction>, Service<Transaction>>();
            services.AddAutoMapper(typeof(TransactionMapper));
        }
    }
}
