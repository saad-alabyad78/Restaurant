using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler
    (ILogger<UpdateRestaurantCommandHandler>logger , 
    IRestaurantsRepository restaurantsRepo , 
    IMapper mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
    {
        public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"updating restaurant {request.Id}") ;

            var restaurant = await restaurantsRepo.GetByIdAsync(request.Id) ;
            if(restaurant is null)
                return false ;

            restaurant.Name = request.Name ?? restaurant.Name ;
            restaurant.Description = request.Description ?? restaurant.Description ;
            restaurant.HasDelivery = request.HasDelivery ?? restaurant.HasDelivery ;

            //mapper.Map(request , restaurant);

            await restaurantsRepo.SaveChangesAsync();
            return true;
        }
    }
}