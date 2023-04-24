using KndStore.Shared.Core.Abstracts;
using KndStore.Shared.Core.Entites;

namespace KndStore.Cart.Core.Entites;

public class CartLine : IEntity
{
    public int Id { get; set; }
    public Product Product { get; set; } = default!;
    public int Quantity { get; set; }
}

