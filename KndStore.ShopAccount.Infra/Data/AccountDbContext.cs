// dotnet ef migrations add "Initial" --startup-project ../KndStore -o Data/Migrations/ --context AccountDbContext

using KndStore.Shared.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace KndStore.ShopAccount.Infra.Data;

public class AccountDbContext : AIdentityDbContext
{
    protected override string Schema => "Identity";

    public AccountDbContext(DbContextOptions options) : base(options)
    {
    }
}