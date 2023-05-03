using KndStore.ShopOrder.Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace KndStore.ShopOrder.Core.Abstracts;

public interface IShopOrderDbContext
{
    public DbSet<Order> Orders { get; }
    DbSet<OrderLine> OrderLines { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new ());
    int SaveChanges();
}

