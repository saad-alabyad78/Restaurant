using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandHandler
    (ILogger<CreateDishCommandHandler> logger ,
    IRestaurantsRepository restaurantsRepository ,
    IMapper mapper ,
    IDishRepository dishRepository) : IRequestHandler<CreateDishCommand , int>
    {
        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("create new dish {@request}" , request);

            var restaurant =  await restaurantsRepository.GetByIdAsync(request.RestaurantId) ;

            if(restaurant is null)
            {
                throw new NotFoundException(
                    resourceType: typeof(Restaurant).ToString() ,
                    resourceId: request.RestaurantId.ToString() 
                );
            }
            
            return await dishRepository.CreateAsync(mapper.Map<Dish>(request));
        }

    }
}