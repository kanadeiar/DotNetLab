using KndStore.ShopOrder.Core.Extensions;
using KndStore.ShopOrder.Infra.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.ShopOrder.Extensions;

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