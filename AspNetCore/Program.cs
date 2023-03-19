var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AspNetCoreDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("AspNetCoreConnection"));
});
builder.Services.AddScoped<IStoreRepository, StoreRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
