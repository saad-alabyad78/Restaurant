using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence
{
    public class RestaurantDbContext : IdentityDbContext<User>
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> dbContextOptions)
        :base(dbContextOptions)
        {
            
        }
        public RestaurantDbContext()
        {
            
        }

        internal DbSet<Restaurant>Restaurants { get; set; }
        internal DbSet<Dish>Dishes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>()
            .OwnsOne(r=>r.Address);

            modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Dishes)
            .WithOne()
            .HasForeignKey(d => d.RestaurantId);
        }
    }
}