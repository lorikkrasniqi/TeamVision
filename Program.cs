using Microsoft.EntityFrameworkCore;
using VisionStore.Data;
using VisionStore.Services;
using VisionStore.Services.IServices;
using Microsoft.AspNetCore.Identity;
using VisionStore.Services;
using VisionStore.Areas.Identity.Data;
using VisionStore.Services.IServices;
using VisionStore.Data.Cart;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("VisionStoreContextConnection");;


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<VisionStore.Areas.Identity.Data.ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>();;


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddScoped<IUnitWork, UnitWork>();
builder.Services.AddScoped<ICategoryService,CategoryServices>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => VisionStore.Data.Cart.ShoppingCart.GetShoppingCart(sc));

builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
