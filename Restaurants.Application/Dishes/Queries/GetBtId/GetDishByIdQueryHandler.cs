using AutoMapper;
using MediatR;
using Restaurants.Application.Dishes.Dto;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetBtId
{
    public class GetDishByIdQueryHandler
    (IRestaurantsRepository restaurantsRepository ,
    IMapper mapper) : IRequestHandler<GetDishByIdQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);

            if(restaurant is null)
            {
                throw new NotFoundException(
                    resourceType: nameof(Restaurant) ,
                    resourceId: request.RestaurantId.ToString() 
                );
            }

            var dish = restaurant.Dishes.Find(dish => dish.Id == request.DishtId) ;

            if(dish is null)
            {
                throw new NotFoundException(
                    resourceType: nameof(Dish) ,
                    resourceId: request.DishtId.ToString() 
                );
            }

            return mapper.Map<DishDto>(dish) ;
        }
    }
}