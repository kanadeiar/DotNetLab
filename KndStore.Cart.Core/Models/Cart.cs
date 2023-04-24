using KndStore.Cart.Core.Entites;
using KndStore.Shared.Core.Abstracts;

namespace KndStore.Cart.Core.Models;

public class Cart
{
    public List<CartLine> Lines { get; set; } = new List<CartLine>();
    public void AddItem(IProduct product, int quantity)
    {
        var line = Lines.FirstOrDefault(x => x.Product?.Id == product.Id);
        if (line == null)
        {
            Lines.Add(new CartLine { Product = product, Quantity = quantity });
        }
        else
        {
            line.Quantity += quantity;
        }
    }
    public void RemoveLine(IProduct product)
    {
        if (Lines.FirstOrDefault(x => x.Product?.Id == product.Id) is { } line)
        {
            Lines.Remove(line);
        }
    }
    public decimal ComputeTotalSum() => Lines.Sum(x => x.Product!.Price * x.Quantity);
    public void Clear() => Lines.Clear();
}

