using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KndStore.Shared.Infra.Data;

public abstract class AIdentityDbContext : IdentityDbContext<IdentityUser>
{
    protected abstract string Schema { get; }
    protected AIdentityDbContext(DbContextOptions options) : base(options)
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