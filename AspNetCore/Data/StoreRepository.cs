namespace AspNetCore.Data;

public class StoreRepository : IStoreRepository
{
    private readonly AspNetCoreDbContext _context;
    public StoreRepository(AspNetCoreDbContext context)
    {
        _context = context;
    }
    public IQueryable<Product> Products => _context.Products;
}