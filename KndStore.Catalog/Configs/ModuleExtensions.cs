using KndStore.Catalog.Core.Configs;
using KndStore.Catalog.Infra.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.Catalog.Configs;

public static class ModuleExtensions
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddCatalogCore()
            .AddCatalogInfrastructure(configuration);
        return services;
    }
}

