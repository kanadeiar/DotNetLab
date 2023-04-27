using KndStore.Shared.Core.Abstracts;

namespace KndStore.Cart.Core.Entites;

public class CartLine : IEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

