using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQueryHandler(IRestaurantsRepository restaurantsRepo ,
    IMapper mapper ,
    ILogger<GetRestaurantByIdQueryHandler> logger) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
    {
        public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Getting restautant by the id {request.Id}");
            
            var res = await restaurantsRepo.GetByIdAsync(request.Id);

            if(res is null)
                throw new NotFoundException(
                    resourceType: typeof(Restaurant).ToString() ,
                    resourceId: request.Id.ToString() 
                );

            return mapper.Map<RestaurantDto>(res); 
        }
    }
}