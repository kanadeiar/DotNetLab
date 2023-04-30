using KndStore.Catalog.Configs;
using KndStore.ShopAccount.Configs;
using KndStore.ShopCart.Configs;
using KndStore.ShopOrder.Configs;

namespace KndStore.Configs;

public static class ModulesExtensions
{
    public static IServiceCollection AddModules(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCatalogModule(configuration);
        services.AddShopOrderModule(configuration);
        services.AddShopCartModule(configuration);
        services.AddShopAccountModule(configuration);
        return services;
    }
}

