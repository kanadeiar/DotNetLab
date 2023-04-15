// dotnet ef migrations add "Initial" --startup-project ../../_Host/WebApplication1 -o Persistence/Migrations/ --context CatalogDbContext
// dotnet ef migrations add "Initial" --startup-project ../../_Host/WebApplication1 --context CatalogDbContext

using Microsoft.EntityFrameworkCore;

namespace Module.Catalog.Infra.Persistence;

public class CatalogDbContext : ModuleDbContext, ICatalogDbContext
{
    protected override string Schema => "Catalog";
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {
    }
    public DbSet<Brand> Brands { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

