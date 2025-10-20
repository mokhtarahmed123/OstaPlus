using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OSTA.DAL.Entities;

namespace OSTA.DAL.Context
{
    public class OstaContext : IdentityDbContext<ApplicationUser>
    {
        #region Table
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Order_Product> Order_Product { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProviderService> ProviderService { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ServiceRequest> ServiceRequest { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<Support> Support { get; set; }





        #endregion
        #region Constractor

        public OstaContext()
        {

        }
        public OstaContext(DbContextOptions<OstaContext> options) : base(options)
        {

        }
        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order_Product>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<Order_Product>()
                .HasOne(op => op.Order)
                .WithMany(o => o.Order_Product)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<Order_Product>()
                .HasOne(op => op.Product)
                .WithMany(p => p.Order_Product)
                .HasForeignKey(op => op.ProductId);

            base.OnModelCreating(modelBuilder);
        }

    }
}

