using MediatR;
using Restaurants.Application.Dishes.Dto;

namespace Restaurants.Application.Dishes.Queries.GetAll
{
    public class GetAllDishesQuery(int restaurantId) : IRequest<IEnumerable<DishDto>>
    {
        public int RestaurantId { get;} = restaurantId ;
    }
}