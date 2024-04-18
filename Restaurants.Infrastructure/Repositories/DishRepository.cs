using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories
{
    public class DishRepository(RestaurantDbContext dbContext) : IDishRepository
    {
        public async Task<int> CreateAsync(Dish dish)
        {
            await dbContext.Dishes.AddAsync(dish) ;
            await dbContext.SaveChangesAsync() ;
            return dish.Id ;
        }

        public async Task DeleteAll(IEnumerable<Dish> dishes)
        {
            dbContext.Dishes.RemoveRange(dishes) ;
            await dbContext.SaveChangesAsync() ;
        }
    }
}