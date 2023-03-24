namespace AspNetCore.Models;

public class Cart
{
    public List<CartLine> Lines { get; set; } = new List<CartLine>();
    public virtual void AddItem(Product product, int quantity)
    {
        var line = Lines.Where(x => x.Product?.Id == product.Id).FirstOrDefault();
        if (line == null)
        {
            Lines.Add(new CartLine { Id = product.Id, Product = product, Quantity = quantity });
        }
        else
        {
            line.Quantity += quantity;
        }
    }
    public virtual void RemoveLine(Product product)
    {
        if (Lines.Where(x => x.Product?.Id == product.Id).FirstOrDefault() is CartLine line)
        {
            Lines.Remove(line);
        }
    }
    public decimal ComputeTotalSum() => Lines.Sum(x => x.Product!.Price * x.Quantity);
    public virtual void Clear() => Lines.Clear();
}