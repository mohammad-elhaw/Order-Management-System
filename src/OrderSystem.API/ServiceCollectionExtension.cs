using Microsoft.Extensions.DependencyInjection;
using OrderSystem.Application;

namespace OrderSystem.API;

public static class ServiceCollectionExtension
{

    public static IServiceCollection AddAPI(this IServiceCollection services)
    {
        services.AddApplication();
        return services;
    }
}
