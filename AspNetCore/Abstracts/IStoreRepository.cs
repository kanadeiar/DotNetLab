namespace AspNetCore.Abstracts;

public interface IStoreRepository
{
    IQueryable<Product> Products { get; }
}