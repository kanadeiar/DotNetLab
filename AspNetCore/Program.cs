var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AspNetCoreDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("AspNetCoreConnection"));
});
builder.WebHost.ConfigureServices(x => {
    x.AddScoped<IStoreRepo, StoreRepo>();
    x.AddScoped<IOrderRepo, OrderRepo>();
    x.AddControllersWithViews();
    x.AddRazorPages();
    x.AddDistributedMemoryCache();
    x.AddSession();
    x.AddScoped<Cart>(x => SessionCart.GetCart(x));
    x.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    x.AddServerSideBlazor();
    x.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AspNetCoreDbContext>();
});

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

app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

SeedData.EnsurePopulated(app);

app.Run();
