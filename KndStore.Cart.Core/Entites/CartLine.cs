using KndStore.Shared.Core.Abstracts;

namespace KndStore.Cart.Core.Entites;

public class CartLine : IEntity
{
    public int Id { get; set; }
    public IProduct Product { get; set; } = default!;
    public int Quantity { get; set; }
}

