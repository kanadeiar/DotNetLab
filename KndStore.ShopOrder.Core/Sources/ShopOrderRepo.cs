using KndStore.ShopOrder.Core.Abstracts;
using KndStore.ShopOrder.Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace KndStore.ShopOrder.Core.Sources;

public class ShopOrderRepo : IShopOrderRepo
{
    private readonly IShopOrderDbContext _context;
    public ShopOrderRepo(IShopOrderDbContext context)
    {
        _context = context;
    }

    public IQueryable<Order> Orders => _context.Orders
        .Include(x => x.Lines);
    public async Task AddOrder(Order order)
    {
        if (order.Id == 0)
        {
            _context.Orders.Add(order);
        }
        await _context.SaveChangesAsync(new CancellationToken());
    }
}

