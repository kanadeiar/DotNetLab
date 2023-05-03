using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.ShopAccount;

public static class AccountSeedData
{
    private const string AdminUser = "admin";
    private const string AdminPassword = "Secret123$";
    public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
    {
        var userManager = app.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();
        var user = await userManager.FindByIdAsync(AdminUser);
        if (user is null)
        {
            user = new IdentityUser(AdminUser);
            user.Email = "admin@example.com";
            user.PhoneNumber = "444-4444";
            await userManager.CreateAsync(user, AdminPassword);
        }
    }
}