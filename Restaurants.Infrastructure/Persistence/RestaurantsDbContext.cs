using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Restaurants.Domain.Entities;
using System.Diagnostics;
using Restaurants.Application.Orders.Dtos;

namespace Restaurants.Infrastructure.Persistence; 
internal class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : DbContext(options) {
    internal DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }
    internal DbSet<Customer> Customers { get; set; }
    internal DbSet<Order> Orders{ get; set; }
    internal DbSet<OrderDetail> OrderDetails{ get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
       base.OnModelCreating(modelBuilder);

        //Restaurants Table
        modelBuilder.Entity<Restaurant>().OwnsOne(r => r.Address);
        modelBuilder.Entity<Restaurant>(entity => {
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Category).IsRequired();
        });
        //Dishes Table
        modelBuilder.Entity<Dish>(entity => {
            //Indexes
            entity.HasIndex(e => e.RestaurantId, "IX_Dishes_RestaurantId").IsUnique(false);
            //Requires
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(6,2)");
            //Foregin Keys
            entity.HasOne(d => d.Restaurant).WithMany(p => p.Dishes).HasForeignKey(d => d.RestaurantId);
        });
        //Customers Table
        modelBuilder.Entity<Customer>().OwnsOne(r => r.Address);
        modelBuilder.Entity<Customer>(entity => {
            //Indexes
            entity.HasIndex(e => e.RestaurantId, "IX_Customers_RestaurantId").IsUnique(false);
            //Requires
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.LastName).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            //Foregin Keys
            entity.HasOne(e => e.Restaurant).WithMany(p => p.Customers).HasForeignKey(d => d.RestaurantId);
            entity.HasOne(e => e.Address).WithOne();
        });
        //Orders Table
        modelBuilder.Entity<Order>(entity => {
            //Indexes
            entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerId").IsUnique(false);
            //Requires
            entity.Property(e => e.OrderDate).IsRequired();
            entity.Property(e => e.OrderStatus).IsRequired();
            entity.Property(e => e.TotalAmount).IsRequired().HasColumnType("decimal(6, 2)");
            //Foreign Keys
            entity.HasOne(e => e.Customer).WithMany(d => d.Orders).HasForeignKey(d => d.CustomerId);

        });
        modelBuilder.Entity<OrderDetail>(entity => {
            //Indexes
            entity.HasIndex(e => e.DishId, "IX_OrderDetails_DishId").IsUnique(false);
            entity.HasIndex(e => e.OrderId, "IX_OrderDetails_OrderId").IsUnique(false);
            //Requires 
            entity.Property(e => e.DishId).IsRequired();
            entity.Property(e => e.OrderId).IsRequired();
            //Foreign Keys
            entity.HasOne(e => e.Dish).WithMany(d => d.OrderDetails).HasForeignKey(b => b.DishId);
            entity.HasOne(e => e.Order).WithMany(d => d.OrderDetails).HasForeignKey(b => b.OrderId);
        });
    }
}