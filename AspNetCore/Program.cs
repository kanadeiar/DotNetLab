var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AspNetCoreDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("AspNetCoreConnection"));
});
builder.Services.AddScoped<IStoreRepo, StoreRepo>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<Cart>(x => SessionCart.GetCart(x));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
// app.MapControllerRoute("catpage", "{category}/Page{productPage:int}", 
//     new { Controller = "Home", Action = "Index" });
// app.MapControllerRoute("page", "Page{productPage:int}",
//     new { Controller = "Home", Action = "Index", productPage = 1 });
// app.MapControllerRoute("category", "{category}",
//     new { Controller = "Home", Action = "Index", productPage = 1 });
// app.MapControllerRoute("pagination", "Products/Page{productPage:int}", 
//     new { Controller = "Home", Action = "Index", productPage = 1 });
app.MapDefaultControllerRoute();
app.MapRazorPages();

SeedData.EnsurePopulated(app);

app.Run();
