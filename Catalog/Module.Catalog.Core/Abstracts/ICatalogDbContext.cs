using Microsoft.EntityFrameworkCore;

namespace Module.Catalog.Core.Abstracts;

public interface ICatalogDbContext
{
    public DbSet<Brand> Brands { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

