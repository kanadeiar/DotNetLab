namespace AspNetCore.Data;

public static class SeedData
{
    public static void EnsurePopulated(IApplicationBuilder app)
    {
        var context = app.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<AspNetCoreDbContext>();
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
        if (!context.Products.Any())
        {
            context.Products.AddRange(
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
                }
            );
        }
        context.SaveChanges();
    }
}