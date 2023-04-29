using KndStore.Catalog;
using KndStore.Catalog.Extensions;
using KndStore.Shared.Extensions;
using KndStore.ShopCart.Core.Models;
using KndStore.ShopCart.Models;
using KndStore.ShopOrder.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().RegisterModules();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddCatalogModule(builder.Configuration);
builder.Services.AddShopOrderModule(builder.Configuration);
builder.Services.AddScoped<Cart>(SessionCart.GetCart);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/error");
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.MapDefaultControllerRoute();
app.MapRazorPages();

CatalogSeedData.EnsurePopulated(app);

app.Run();
