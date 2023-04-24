using KndStore.Catalog;
using KndStore.Catalog.Extensions;
using KndStore.Shared.Core.Abstracts;
using KndStore.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().RegisterModules();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddCatalogModule(builder.Configuration);

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
