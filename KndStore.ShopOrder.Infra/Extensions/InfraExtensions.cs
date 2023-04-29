using KndStore.Shared.Infra.Extensions;
using KndStore.ShopOrder.Core.Abstracts;
using KndStore.ShopOrder.Core.Sources;
using KndStore.ShopOrder.Infra.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.ShopOrder.Infra.Extensions;

public static class InfraExtensions
{
    public static IServiceCollection AddShopOrderInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddDatabaseContext<ShopOrderDbContext>(config)
            .AddScoped<IShopOrderDbContext>(provider =>
                provider.GetService<ShopOrderDbContext>() ?? throw new InvalidOperationException());
        return services;
    }
}