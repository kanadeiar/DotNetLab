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
    public void AddOrder(Order order)
    {
        _context.OrderLines.AddRange(order.Lines);
        _context.SaveChanges();

        if (order.Id == 0)
        {
            _context.Orders.Add(order);
        }
        _context.SaveChanges();
    }
}

