using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteAll
{
    public class DeleteAllDishesCommand(int restaurantId) : IRequest
    {
        public int RestaurantId { get;} = restaurantId ;
    }
}