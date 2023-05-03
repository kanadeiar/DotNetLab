using KndStore.ShopAccount.Core.Configs;
using KndStore.ShopAccount.Infra.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.ShopAccount.Configs;

public static class ModuleExtensions
{
    public static IServiceCollection AddShopAccountModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddShopAccountCore()
            .AddShopAccountInfrastructure(configuration);
        return services;
    }
}