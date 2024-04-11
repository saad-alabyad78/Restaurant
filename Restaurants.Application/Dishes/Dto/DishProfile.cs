using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.Dto
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish , DishDto>();
        }
    }
}