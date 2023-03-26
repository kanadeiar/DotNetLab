namespace AspNetCore.Abstracts;

public interface IStoreRepo
{
    IQueryable<Product> Products { get; }
    void CreateProduct(Product p);
    void UpdateProduct(Product p);
    void DeleteProduct(Product p);
}