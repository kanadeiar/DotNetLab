namespace AspNetCore.Data;

public class AspNetCoreDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public AspNetCoreDbContext(DbContextOptions<AspNetCoreDbContext> options) : base(options)
    { }
}