using MediatR;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepo) : IRequestHandler<DeleteRestaurantCommand>
    {
        public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepo.GetByIdAsync(request.Id) ;

            if(restaurant is null)
                throw new NotFoundException(
                    resourceType: typeof(Restaurant).ToString() ,
                    resourceId: request.Id.ToString()
                );

            await restaurantsRepo.DeleteAsync(restaurant);
        }
    }
}