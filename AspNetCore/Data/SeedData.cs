namespace AspNetCore.Data;

public static class SeedData
{
    private const string adminUser = "admin";
    private const string adminPassword = "Secret123$";
    public static async void EnsurePopulated(IApplicationBuilder app)
    {
        var context = app.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<AspNetCoreDbContext>();
        if (context.Database.GetPendingMigrations().Any())
        {
            await context.Database.MigrateAsync();
        }
        var userManager = app.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();
        var user = await userManager.FindByIdAsync(adminUser);
        if (user is null)
        {
            user = new IdentityUser(adminUser);
            user.Email = "admin@example.com";
            user.PhoneNumber = "444-4444";
            await userManager.CreateAsync(user, adminPassword);
        }
        if (!context.Products.Any())
        {
            await context.Products.AddRangeAsync(
                new Product {
                    Name = "Шорты",
                    Description = "Обычные спортивные шорты",
                    Category = "Спорт",
                    Price = 275,
                },
                new Product {
                    Name = "Кроссовки",
                    Description = "Супер модные кроссовки для занятия спортом",
                    Category = "Спорт",
                    Price = 112,
                },
                new Product {
                    Name = "Мячик",
                    Description = "Мячик для игры в футбол",
                    Category = "Футбол",
                    Price = 11.6m,
                },
                new Product {
                    Name = "Флаг",
                    Description = "Флаг для болельщика",
                    Category = "Футбол",
                    Price = 11294,
                },
                new Product {
                    Name = "Футболка",
                    Description = "Футболка футболиста",
                    Category = "Футбол",
                    Price = 11294,
                },
                new Product {
                    Name = "Игровая доска",
                    Description = "Доска для игры в шахматы по традиционным плавилам.",
                    Category = "Шахматы",
                    Price = 11,
                },
                new Product {
                    Name = "Фигурка пешки",
                    Description = "Фигурка для установки на игровую доску",
                    Category = "Шахматы",
                    Price = 99,
                },
                new Product {
                    Name = "Фигурка ладьи",
                    Description = "Ладья.",
                    Category = "Шахматы",
                    Price = 999,
                },
                new Product {
                    Name = "Фигурка коня",
                    Description = "Конь ходит буквой гэ",
                    Category = "Шахматы",
                    Price = 99.9m,
                }
            );
        }
        await context.SaveChangesAsync();
    }
}