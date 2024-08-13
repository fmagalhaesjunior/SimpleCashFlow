using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.Contexts;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Application.Configuration.DependencyInjection
{
    public static class InfrastructureDI
    {
        public static void AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<TransactionContext>((provider, options) =>
            {
                options.UseNpgsql(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });

            services.AddScoped<IRepository<Transaction>, Repository<Transaction>>();
        }
    }
}
