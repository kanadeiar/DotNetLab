using KndStore.ShopOrder.Core.Entites;

namespace KndStore.ShopOrder.Core.Abstracts;

public interface IShopOrderRepo
{
    IQueryable<Order> Orders { get; }
    void AddOrder(Order order);
}