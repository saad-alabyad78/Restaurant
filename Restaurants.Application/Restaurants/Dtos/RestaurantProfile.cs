using AutoMapper;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<CreateRestaurantCommand , Restaurant>();
            CreateMap<UpdateRestaurantCommand , Restaurant>();

            CreateMap<Restaurant , RestaurantDto>()
            .ForMember(r => r.Dishes , opt => opt.MapFrom(src => src.Dishes));
        }
    }
}