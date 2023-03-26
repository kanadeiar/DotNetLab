namespace AspNetCore.Data;

public class StoreRepo : IStoreRepo
{
    private readonly DbContext _context;
    public StoreRepo(AspNetCoreDbContext context)
    {
        _context = context;
    }
    public IQueryable<Product> Products => _context.Set<Product>();
}