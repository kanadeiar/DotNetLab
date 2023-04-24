using KndStore.Catalog.Core.Abstracts;
using KndStore.Catalog.Core.Sources;
using KndStore.Catalog.Infra.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KndStore.Shared.Infra.Extensions;

namespace KndStore.Catalog.Infra.Extensions;

public static class InfraExtensions
{
    public static IServiceCollection AddCatalogInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddDatabaseContext<CatalogDbContext>(config)
            .AddScoped<ICatalogDbContext>(provider => 
                provider.GetService<CatalogDbContext>() ?? throw new InvalidOperationException());
        return services;
    }
}

