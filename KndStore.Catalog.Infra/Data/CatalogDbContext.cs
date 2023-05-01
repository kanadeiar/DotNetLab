// dotnet ef migrations add "Initial" --startup-project ../KndStore -o Data/Migrations/ --context CatalogDbContext

using KndStore.Catalog.Core.Abstracts;
using KndStore.Catalog.Core.Entites;
using KndStore.Shared.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace KndStore.Catalog.Infra.Data;

public class CatalogDbContext : ASharedDbContext, ICatalogDbContext
{
    protected override string Schema => "Catalog";
    public DbSet<Product> Products => Set<Product>();

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {
    }
}

