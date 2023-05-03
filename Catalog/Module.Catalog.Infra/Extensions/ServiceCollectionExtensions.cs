using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Catalog.Core.Abstracts;
using Module.Catalog.Infra.Persistence;
using Shared.Infra.Extensions;

namespace Module.Catalog.Infra.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCatalogInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddDatabaseContext<CatalogDbContext>(config)
            .AddScoped<ICatalogDbContext>(provider => provider.GetService<CatalogDbContext>());
        return services;
    }
}

