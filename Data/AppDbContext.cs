using Microsoft.EntityFrameworkCore;
using VisionStore.Models;


namespace VisionStore.Data
{
    public class AppDbContext : DbContext
    {
      
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

        public DbSet<Order> Actors { get; set; }
        public DbSet<Products> Movies { get; set; }
        public DbSet<OrderedProducts> Actors_Movies { get; set; }
        public DbSet<Roles> Cinemas { get; set; }
        public DbSet<User> Producers { get; set; }
    }
}
