using Microsoft.Extensions.DependencyInjection;
using OrderSystem.Infrastructure;
using OrderSystem.Queries;
using System.Reflection;

namespace OrderSystem.Application;

public static class ServiceCollectionExtension
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        services.AddInfrastructure();
        services.AddQueries();
        return services;
    }
}
