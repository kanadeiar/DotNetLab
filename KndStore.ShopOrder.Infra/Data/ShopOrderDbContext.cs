﻿// dotnet ef migrations add "Initial" --startup-project ../KndStore -o Data/Migrations/ --context ShopOrderDbContext

using KndStore.Shared.Infra.Data;
using KndStore.ShopOrder.Core.Abstracts;
using KndStore.ShopOrder.Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace KndStore.ShopOrder.Infra.Data;

public class ShopOrderDbContext : SharedDbContext, IShopOrderDbContext
{
    protected override string Schema => "ShopOrder";
    public DbSet<Order> Orders => Set<Order>();

    public ShopOrderDbContext(DbContextOptions<ShopOrderDbContext> options) : base(options)
    {
    }


}