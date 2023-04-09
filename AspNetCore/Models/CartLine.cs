namespace AspNetCore.Models;

public class CartLine
{
    public int Id { get; set; }
    public Product Product { get; set; } = new Product();
    public int Quantity { get; set; }
}