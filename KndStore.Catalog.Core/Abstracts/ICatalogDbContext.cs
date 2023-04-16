using KndStore.Catalog.Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace KndStore.Catalog.Core.Abstracts;

public interface ICatalogDbContext
{
    public DbSet<Product> Products { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

