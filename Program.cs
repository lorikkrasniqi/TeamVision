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
var connectionString = builder.Configuration.GetConnectionString("VisionStoreContextConnection");


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
//  /* .AddRoles<IdentityRole>()*/.AddEntityFrameworkStores<AppDbContext>();

//builder.Services.AddDefaultIdentity<IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)yRole>()
//    .AddEntityFrameworkStores<AppDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddScoped<ICategoryService,CategoryServices>();
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => VisionStore.Data.Cart.ShoppingCart.GetShoppingCart(sc));
builder.Services.AddScoped(sc => VisionStore.Data.Cart.ProductDeals.GetProduct(sc));


builder.Services.AddSession();
 

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddMvc();
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
await AppDbInitializer.SeedUserRolesAsync(app);

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
