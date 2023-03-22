namespace AspNetCore.ViewModels;

public class ProductsListViewModel
{
    public IEnumerable<Product> Products { get; set; } = Array.Empty<Product>();
    public PagingInfo? PagingInfo { get; set; }
    public string? CurrentCategory { get; set; }
}