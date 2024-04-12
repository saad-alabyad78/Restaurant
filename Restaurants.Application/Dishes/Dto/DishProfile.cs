using AutoMapper;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.Dto
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<CreateDishCommand , Dish>();
            CreateMap<Dish , DishDto>();
        }
    }
}