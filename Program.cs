using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VisionStore.Data;
using VisionStore.Areas.Identity.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("VisionStoreContextConnection") ?? throw new InvalidOperationException("Connection string 'VisionStoreContextConnection' not found.");

builder.Services.AddDbContext<VisionStoreContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<VisionStoreUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<VisionStoreContext>();;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
