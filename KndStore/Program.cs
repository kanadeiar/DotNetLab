using KndStore.Catalog;
using KndStore.Configs;
using KndStore.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().RegisterModules();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddModules(builder.Configuration);
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
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

CatalogSeedData.EnsurePopulated(app);

app.Run();
