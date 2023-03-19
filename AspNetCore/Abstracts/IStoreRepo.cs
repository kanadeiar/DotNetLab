namespace AspNetCore.Abstracts;

public interface IStoreRepo
{
    IQueryable<Product> Products { get; }
}