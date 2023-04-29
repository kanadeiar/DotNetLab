using KndStore.Catalog.Core.Abstracts;
using KndStore.Catalog.Infra.Data;
using KndStore.Shared.Infra.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.Catalog.Infra.Configs;

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

