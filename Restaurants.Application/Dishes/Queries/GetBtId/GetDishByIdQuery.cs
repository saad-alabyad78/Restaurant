using MediatR;
using Restaurants.Application.Dishes.Dto;

namespace Restaurants.Application.Dishes.Queries.GetBtId
{
    public class GetDishByIdQuery(int restaurantId , int dishId) : IRequest<DishDto>
    {
        public int RestaurantId { get;} = restaurantId ;
        public int DishtId { get;} = dishId ;
    }
}