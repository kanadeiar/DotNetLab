using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Module.Catalog.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCatalogCore(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}

