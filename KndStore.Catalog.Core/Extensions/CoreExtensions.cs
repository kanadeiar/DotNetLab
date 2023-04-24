using KndStore.Catalog.Core.Sources;
using KndStore.Shared.Core.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.Catalog.Core.Extensions;

public static class CoreExtensions
{
    public static IServiceCollection AddCatalogCore(this IServiceCollection services)
    {
        services.AddScoped<ICatalogRepo, CatalogRepo>();
        return services;
    }
}

