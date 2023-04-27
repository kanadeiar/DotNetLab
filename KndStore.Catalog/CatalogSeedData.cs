using KndStore.Catalog.Core.Entites;
using KndStore.Catalog.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace KndStore.Catalog;

public static class CatalogSeedData
{
    public static void EnsurePopulated(IApplicationBuilder app)
    {
        var context = app.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<CatalogDbContext>();
        if (!context.Products.Any())
        {
            context.Products.AddRange(
                new Product
                {
                    Name = "Рокетка",
                    Description = "Теннисная рокетка для игры в теннис",
                    Category = "Теннс",
                    Price = 27.9m,
                },
                new Product
                {
                    Name = "Шорты",
                    Description = "Обычные спортивные шорты",
                    Category = "Спорт",
                    Price = 275,
                },
                new Product
                {
                    Name = "Кроссовки",
                    Description = "Супер модные кроссовки для занятия спортом",
                    Category = "Спорт",
                    Price = 112,
                },
                new Product
                {
                    Name = "Мячик",
                    Description = "Мячик для игры в футбол",
                    Category = "Футбол",
                    Price = 11.6m,
                },
                new Product
                {
                    Name = "Флаг",
                    Description = "Флаг для болельщика",
                    Category = "Футбол",
                    Price = 11294,
                },
                new Product
                {
                    Name = "Футболка",
                    Description = "Футболка футболиста",
                    Category = "Футбол",
                    Price = 11294,
                },
                new Product
                {
                    Name = "Игровая доска",
                    Description = "Доска для игры в шахматы по традиционным плавилам.",
                    Category = "Шахматы",
                    Price = 11,
                },
                new Product
                {
                    Name = "Фигурка пешки",
                    Description = "Фигурка для установки на игровую доску",
                    Category = "Шахматы",
                    Price = 99,
                },
                new Product
                {
                    Name = "Фигурка ладьи",
                    Description = "Ладья.",
                    Category = "Шахматы",
                    Price = 999,
                },
                new Product
                {
                    Name = "Фигурка коня",
                    Description = "Конь ходит буквой гэ",
                    Category = "Шахматы",
                    Price = 99.9m,
                },
                new Product
                {
                    Name = "Фигурка ферзя",
                    Description = "Ферзь",
                    Category = "Шахматы",
                    Price = 99,
                },
                new Product
                {
                    Name = "Фигурка короля",
                    Description = "Все берегут короля",
                    Category = "Шахматы",
                    Price = 55m,
                }
            );
        }
        context.SaveChanges();
    }
}

