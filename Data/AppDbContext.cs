using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VisionStore.Areas.Identity.Data;
using VisionStore.Models;


namespace VisionStore.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OrderedProducts>().HasKey(am => new
            {
                am.OrderID,
                am.ProductID
            });

            modelBuilder.Entity<OrderedProducts>().HasOne(m => m.Orders).WithMany(am => am.OrderedProducts)
                .HasForeignKey(m => m.OrderID);
            modelBuilder.Entity<OrderedProducts>().HasOne(a => a.Products).WithMany(am => am.OrderedProducts)
                .HasForeignKey(a => a.ProductID);

            modelBuilder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
        public DbSet<OrderedProducts> OrderedProducts { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
    
    }
}
public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        
    }
}