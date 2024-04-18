using AutoMapper;
using MediatR;
using Restaurants.Application.Dishes.Dto;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetAll
{
    public class GetAllDishesQueryHandler
    (IRestaurantsRepository restaurantsRepository ,
    IMapper mapper) : IRequestHandler<GetAllDishesQuery, IEnumerable<DishDto>>
    {
        public async Task<IEnumerable<DishDto>> Handle(GetAllDishesQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId) ;

            if(restaurant is null){
                throw new NotFoundException(
                    resourceType: nameof(Restaurant) , 
                    resourceId: request.RestaurantId.ToString()
                );
            }

            return mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes) ;
        }
    }
}