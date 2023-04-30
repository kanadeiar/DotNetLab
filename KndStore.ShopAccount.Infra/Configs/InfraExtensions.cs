using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.ShopAccount.Infra.Configs;

public static class InfraExtensions
{
    public static IServiceCollection AddShopAccountInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        

        return services;
    }
}