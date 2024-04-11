using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.Dto
{
    public class DishDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int? KiloCalories { get; set; }

    
    }
}