using Microsoft.EntityFrameworkCore;
using VisionStore.Models;


namespace VisionStore.Data
{
    public class AppDbContext : DbContext
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


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<OrderedProducts> OrderedProducts { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
