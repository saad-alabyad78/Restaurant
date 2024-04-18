using FluentValidation;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(dish => dish.Name)
            .NotEmpty()
            .Length(3 , 33) ;

            RuleFor(dish => dish.Description)
            .NotEmpty()
            .Length(10 , 2000) ;

            RuleFor(dish => dish.KiloCalories)
            .GreaterThan(0);
        }
    }
}