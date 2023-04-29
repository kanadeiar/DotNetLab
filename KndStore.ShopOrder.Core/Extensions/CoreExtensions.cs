using KndStore.Shared.Core.Abstracts;
using KndStore.ShopOrder.Core.Abstracts;
using KndStore.ShopOrder.Core.Sources;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.ShopOrder.Core.Extensions;

public static class CoreExtensions
{
    public static IServiceCollection AddShopOrderCore(this IServiceCollection services)
    {
        services.AddScoped<IShopOrderRepo, ShopOrderRepo>();
        return services;
    }
}