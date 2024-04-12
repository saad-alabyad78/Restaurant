using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler
    (ILogger<UpdateRestaurantCommandHandler>logger , 
    IRestaurantsRepository restaurantsRepo) : IRequestHandler<UpdateRestaurantCommand>
    {
        public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"updating restaurant {request.Id}") ;

            var restaurant = await restaurantsRepo.GetByIdAsync(request.Id) ;
            if(restaurant is null)
                throw new NotFoundException(
                    resourceType: typeof(Restaurant).ToString() ,
                    resourceId: request.Id.ToString()
                );

            restaurant.Name = request.Name ?? restaurant.Name ;
            restaurant.Description = request.Description ?? restaurant.Description ;
            restaurant.HasDelivery = request.HasDelivery ?? restaurant.HasDelivery ;

            //mapper.Map(request , restaurant);

            await restaurantsRepo.SaveChangesAsync();
        }
    }
}