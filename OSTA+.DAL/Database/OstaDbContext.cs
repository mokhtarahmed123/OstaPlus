using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OSTA_.DAL.Entities;
using System;
using System.Linq;

namespace OSTA_.DAL.Database
{
    public class OstaDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public OstaDbContext(DbContextOptions<OstaDbContext> options)
            : base(options)
        {
        }

        // ---------- DbSets ----------
        public DbSet<User> Users => Set<User>();
        public DbSet<BusinessRole> BusinessRoles => Set<BusinessRole>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Service> Services => Set<Service>();
        public DbSet<ProviderService> ProviderServices => Set<ProviderService>();
        public DbSet<ServiceRequest> ServiceRequests => Set<ServiceRequest>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();
        public DbSet<Store> Stores => Set<Store>();
        public DbSet<Subscription> Subscriptions => Set<Subscription>();
        public DbSet<Support> Supports => Set<Support>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ---------- ApplicationUser ↔ User link ----------
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(a => a.LinkedUser)
                .WithOne(u => u.ApplicationUser)
                .HasForeignKey<ApplicationUser>(a => a.LinkedUserId)
                .OnDelete(DeleteBehavior.Restrict); // avoid cascade loop

            // ---------- USER ↔ BUSINESS ROLE ----------
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- CATEGORY ----------
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Services)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- SERVICE ----------
            modelBuilder.Entity<Service>()
                .HasMany(s => s.ProviderServices)
                .WithOne(ps => ps.Service)
                .HasForeignKey(ps => ps.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- PROVIDER SERVICE ----------
            modelBuilder.Entity<ProviderService>()
                .HasKey(ps => new { ps.ProviderId, ps.ServiceId });

            modelBuilder.Entity<ProviderService>()
                .HasOne(ps => ps.Provider)
                .WithMany(p => p.ProviderServices)
                .HasForeignKey(ps => ps.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- SERVICE REQUEST ----------
            modelBuilder.Entity<ServiceRequest>()
                .HasOne(sr => sr.Client)
                .WithMany(u => u.ServiceRequests)
                .HasForeignKey(sr => sr.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServiceRequest>()
                .HasOne(sr => sr.Category)
                .WithMany()
                .HasForeignKey(sr => sr.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ServiceRequest>()
                .HasOne(sr => sr.Service)
                .WithMany()
                .HasForeignKey(sr => sr.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- APPOINTMENT ----------
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Request)
                .WithMany(r => r.Appointments)
                .HasForeignKey(a => a.RequestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Provider)
                .WithMany()
                .HasForeignKey(a => a.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- PAYMENT ----------
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Appointment)
                .WithMany(a => a.Payments)
                .HasForeignKey(p => p.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Request)
                .WithMany()
                .HasForeignKey(p => p.RequestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne<User>()
                .WithMany(u => u.PaymentsMade)
                .HasForeignKey(p => p.PayerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne<User>()
                .WithMany(u => u.PaymentsReceived)
                .HasForeignKey(p => p.PayeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- REVIEW ----------
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Appointment)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- PRODUCT ----------
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderProducts)
                .WithOne(op => op.Product)
                .HasForeignKey(op => op.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- ORDER ----------
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- ORDER PRODUCT ----------
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- STORE ----------
            modelBuilder.Entity<Store>()
                .HasOne(s => s.Owner)
                .WithMany(u => u.Stores)
                .HasForeignKey(s => s.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- SUBSCRIPTION ----------
            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Client)
                .WithMany(u => u.Subscriptions)
                .HasForeignKey(s => s.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- SUPPORT ----------
            modelBuilder.Entity<Support>()
                .HasOne(s => s.User)
                .WithMany(u => u.Supports)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------- ENUM → STRING Conversion ----------
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties().Where(p => p.ClrType.IsEnum))
                {
                    var converterType = typeof(EnumToStringConverter<>).MakeGenericType(property.ClrType);
                    var converter = (ValueConverter)Activator.CreateInstance(converterType)!;
                    property.SetValueConverter(converter);
                }
            }
        }
    }
}
