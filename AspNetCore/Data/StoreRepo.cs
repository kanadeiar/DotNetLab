namespace AspNetCore.Data;

public class StoreRepo : IStoreRepo
{
    private readonly AspNetCoreDbContext _context;
    public StoreRepo(AspNetCoreDbContext context)
    {
        _context = context;
    }
    public IQueryable<Product> Products => _context.Products;
}