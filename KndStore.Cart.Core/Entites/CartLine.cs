using KndStore.Shared.Core.Abstracts;

namespace KndStore.ShopCart.Core.Entites;

public class CartLine : ICartLine
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

