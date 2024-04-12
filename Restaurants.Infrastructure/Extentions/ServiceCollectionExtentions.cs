using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("aspdb") ;
            services.AddDbContext<RestaurantDbContext>(options => 
                options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging()

            );

            //seeder
            services.AddScoped<IRestaurantsSeeder , RestaurantSeeder>();

            //repositories
            services.AddScoped<IRestaurantsRepository , RestaurantsRepository>() ;
            services.AddScoped<IDishRepository , DishRepository>() ;
        }
    }
}