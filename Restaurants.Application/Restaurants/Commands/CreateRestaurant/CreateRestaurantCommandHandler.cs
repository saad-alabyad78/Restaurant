using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler
    (ILogger<CreateRestaurantCommandHandler> logger ,
    IMapper mapper ,
    IRestaurantsRepository restaurantsRepo) : IRequestHandler<CreateRestaurantCommand, int>
    {
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("creating new restaurant") ;
            logger.LogInformation(request.ToString()) ;

            var resId = await restaurantsRepo.CreateAsync(mapper.Map<Restaurant>(request));
            return resId ;
        }
    }
}