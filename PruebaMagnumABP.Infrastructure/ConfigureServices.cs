using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaMagnumABP.Application.Interfaces.Contexts;
using PruebaMagnumABP.Infrastructure.Persistence.DbContexts;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PruebaMagnumDB"), cfg =>
                {
                    cfg.EnableRetryOnFailure();
                });

            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            return services;
        }
    }
}