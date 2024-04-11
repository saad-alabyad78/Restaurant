using FluentValidation;


namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurandtCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurandtCommandValidator()
        {
            RuleFor(dto => dto.Name)
            .Length( 5 , 10).WithMessage("haha too small or too big") ;
        }
    }
}