using Restaurants.Application.Dishes.Dto;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool HasDelivery { get; set; }
        public Address? Address { get; set; }
        public List<DishDto> Dishes { get; set; } = [];
    }
}