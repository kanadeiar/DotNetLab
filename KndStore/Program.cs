using KndStore.Catalog;
using KndStore.Catalog.Extensions;
using KndStore.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().RegisterModules();
builder.Services.AddCatalogModule(builder.Configuration);

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();

CatalogSeedData.EnsurePopulated(app);

app.Run();
