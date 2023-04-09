namespace AspNetCore.Data;

public class AspNetCoreDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();
    public AspNetCoreDbContext(DbContextOptions<AspNetCoreDbContext> options) : base(options)
    { }
}