using KndStore.Catalog.Core.Abstracts;
using KndStore.Catalog.Core.Sources;
using KndStore.Shared.Core.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.Catalog.Core.Configs;

public static class CoreExtensions
{
    public static IServiceCollection AddCatalogCore(this IServiceCollection services)
    {
        services.AddScoped<ICatalogRepo, CatalogRepo>();
        services.AddScoped<IRepo<IProduct>, CatalogRepo>();
        return services;
    }
}

