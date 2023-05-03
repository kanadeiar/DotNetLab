using KndStore.Shared.Core.Abstracts;

namespace KndStore.ShopOrder.Core.Entites;

public class OrderLine : IEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}