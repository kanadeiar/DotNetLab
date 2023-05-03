using KndStore.ShopOrder.Core.Abstracts;
using KndStore.ShopOrder.Core.Sources;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.ShopOrder.Core.Configs;

public static class CoreExtensions
{
    public static IServiceCollection AddShopOrderCore(this IServiceCollection services)
    {
        services.AddScoped<IShopOrderRepo, ShopOrderRepo>();
        return services;
    }
}