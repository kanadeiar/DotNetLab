namespace AspNetCore.Models;

public class CartLine
{
    public int Id;
    public Product? Product { get; set; }
    public int Quantity { get; set; }
}