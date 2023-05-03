using KndStore.ShopOrder.Core.Configs;
using KndStore.ShopOrder.Infra.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.ShopOrder.Configs;

public static class ModuleExtensions
{
    public static IServiceCollection AddShopOrderModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddShopOrderCore()
            .AddShopOrderInfrastructure(configuration);
        return services;
    }
}