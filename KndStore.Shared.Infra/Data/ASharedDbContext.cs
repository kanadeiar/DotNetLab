using Microsoft.EntityFrameworkCore;

namespace KndStore.Shared.Infra.Data;

public abstract class ASharedDbContext : DbContext
{
    protected abstract string Schema { get; }
    protected ASharedDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (!string.IsNullOrWhiteSpace(Schema))
        {
            modelBuilder.HasDefaultSchema(Schema);
        }
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return (await base.SaveChangesAsync(true, cancellationToken));
    }
}

