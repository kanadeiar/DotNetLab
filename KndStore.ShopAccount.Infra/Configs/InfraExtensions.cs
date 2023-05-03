using KndStore.Shared.Infra.Extensions;
using KndStore.ShopAccount.Infra.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.ShopAccount.Infra.Configs;

public static class InfraExtensions
{
    public static IServiceCollection AddShopAccountInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddDatabaseContext<AccountDbContext>(config);

        return services;
    }
}