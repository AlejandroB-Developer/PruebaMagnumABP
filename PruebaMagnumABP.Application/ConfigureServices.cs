using Carter;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using PruebaMagnumABP.Application.Interfaces.Services;
using PruebaMagnumABP.Application.Services;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddCarter();

            services.AddTransient<IGameService, GameService>();

            return services;
        }
    }
}