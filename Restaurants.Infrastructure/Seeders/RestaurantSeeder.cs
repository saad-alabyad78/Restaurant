using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders
{
    public class RestaurantSeeder(RestaurantDbContext dbContext) : IRestaurantsSeeder
    {
        public async Task Seed()
        {
            if(!await dbContext.Database.CanConnectAsync()) return; 
                
            if(!await dbContext.Restaurants.AnyAsync())
            {
                var restaurants = GetRestaurants();
                await dbContext.Restaurants.AddRangeAsync(restaurants);
                await dbContext.SaveChangesAsync();
            }
            
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurants = [
                new()
                {
                    Name = "kfc2" ,
                    Category = "fast food2" ,
                    Description = "description2" ,
                    ContactEmail = "email2" ,
                    ContactNumber = "number2" ,
                    HasDelivery = false ,
                    Dishes = 
                    [
                        new()
                        {
                            Name = "mahashee2" ,
                            Description = "oisheee2" ,
                            KiloCalories = 10000
                        },
                        new()
                        {
                            Name = "kobba2" ,
                            Description = "oisheee2" ,
                            KiloCalories = 33
                        }
                    ],
                    Address = new()
                    {
                        City = "Damascus2" ,
                        Streed = "Damascus Street2"                    
                    }

                },
                new()
                {
                    Name = "kfc" ,
                    Category = "fast food" ,
                    Description = "description" ,
                    ContactEmail = "email" ,
                    ContactNumber = "number" ,
                    HasDelivery = true ,
                    Dishes = 
                    [
                        new()
                        {
                            Name = "mahashee" ,
                            Description = "oisheee" 
                        },
                        new()
                        {
                            Name = "kobba" ,
                            Description = "oisheee" 
                        }
                    ],
                    Address = new()
                    {
                        City = "Damascus" ,
                        Streed = "Damascus Street"                    
                    }

                }
            ];
            return restaurants ;
        }
    }
}