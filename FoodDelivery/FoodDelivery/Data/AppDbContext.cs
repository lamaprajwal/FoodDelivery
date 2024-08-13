using FoodDelivery.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }
      

        public DbSet<MenuItem> MenuItems { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>()
              .HasMany(r => r.MenuItems)
              .WithOne(m => m.Resturant)
              .HasForeignKey(m => m.ResturantId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Restaurant>()
              .HasMany(r => r.Categories)
              .WithOne(m => m.Restaurant)
              .HasForeignKey(m => m.RestaurantID)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
          .HasMany<MenuItem>()
          .WithOne(m => m.Category)
          .HasForeignKey(m => m.CategoryId)
          .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MenuItem>()
      .HasOne(m => m.Resturant)
      .WithMany(r => r.MenuItems)
      .HasForeignKey(m => m.ResturantId)
      .OnDelete(DeleteBehavior.NoAction);

        }
    }

    }
        






    

