using KndStore.Catalog.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KndStore.Catalog.Infra.Extensions;

namespace KndStore.Catalog.Extensions;

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

