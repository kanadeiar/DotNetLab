using KndStore.Shared.Core.Abstracts;
using KndStore.ShopCart.Core.Models;
using KndStore.ShopCart.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.ShopCart.Configs;

public static class ModuleExtensions
{
    public static IServiceCollection AddShopCartModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<Cart>(SessionCart.GetCart);
        services.AddScoped<ISharedCart>(provider => 
            provider.GetRequiredService<Cart>() ?? throw new InvalidOperationException());

        return services;
    }
}