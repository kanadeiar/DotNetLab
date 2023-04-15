using Microsoft.Extensions.Configuration;
using Module.Catalog.Core.Extensions;
using Module.Catalog.Infra.Extensions;

namespace Module.Catalog;

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

