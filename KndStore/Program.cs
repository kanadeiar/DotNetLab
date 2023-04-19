using KndStore.Catalog;
using KndStore.Catalog.Extensions;
using KndStore.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().RegisterModules();
builder.Services.AddRazorPages();
builder.Services.AddCatalogModule(builder.Configuration);

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();
app.MapRazorPages();

CatalogSeedData.EnsurePopulated(app);

app.Run();
