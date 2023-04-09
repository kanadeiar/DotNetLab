namespace AspNetCore.Data;

public class StoreRepo : IStoreRepo
{
    private readonly DbContext _context;
    public StoreRepo(AspNetCoreDbContext context)
    {
        _context = context;
    }
    public IQueryable<Product> Products => _context.Set<Product>();
    public void CreateProduct(Product p)
    {
        _context.Add(p);
        _context.SaveChanges();
    }
    public void UpdateProduct(Product p)
    {
        _context.SaveChanges();
    }
    public void DeleteProduct(Product p)
    {
        _context.Remove(p);
        _context.SaveChanges();
    }
}