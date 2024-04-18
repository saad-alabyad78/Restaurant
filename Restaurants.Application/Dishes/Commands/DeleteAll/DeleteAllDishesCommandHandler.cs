using MediatR;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteAll
{
    public class DeleteAllDishesCommandHandler
    (IRestaurantsRepository restaurantsRepository , 
    IDishRepository dishRepository ) : IRequestHandler<DeleteAllDishesCommand>
    {
        public async Task Handle(DeleteAllDishesCommand request, CancellationToken cancellationToken)
        {
            var restaurant =  await restaurantsRepository.GetByIdAsync(request.RestaurantId) ;

            if(restaurant is null)
            {
                throw new NotFoundException(
                    resourceType: typeof(Restaurant).ToString() ,
                    resourceId: request.RestaurantId.ToString() 
                );
            }

            await dishRepository.DeleteAll(restaurant.Dishes) ;
        }
    }
}