using KndStore.ShopCart.Core.Models;
using KndStore.ShopCart.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.ShopCart.Extensions;

public static class ModuleExtensions
{
    public static IServiceCollection AddShopCartModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<Cart>(SessionCart.GetCart);

        return services;
    }
}