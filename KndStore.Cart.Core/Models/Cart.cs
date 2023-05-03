using KndStore.Shared.Core.Abstracts;
using KndStore.ShopCart.Core.Entites;

namespace KndStore.ShopCart.Core.Models;

public class Cart : ISharedCart
{
    public IList<CartLine> Lines { get; set; } = new List<CartLine>();
    public virtual void AddItem(int productId, int quantity)
    {
        var line = Lines.FirstOrDefault(x => x.ProductId == productId);
        if (line == null)
        {
            Lines.Add(new CartLine { ProductId = productId, Quantity = quantity });
        }
        else
        {
            line.Quantity += quantity;
        }
    }

    public virtual void RemoveLine(int productId)
    {
        if (Lines.FirstOrDefault(x => x.ProductId == productId) is { } line)
        {
            Lines.Remove(line);
        }
    }

    public virtual void Clear() => Lines.Clear();
    public IEnumerable<ICartLine> GetLines() => Lines;
}

