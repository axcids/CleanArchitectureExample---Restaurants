using FluentValidation;

namespace Restaurants.Application.Dishes.Commands.CreateDish; 
public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand> {
    public CreateDishCommandValidator() {

        RuleFor(x => x.Name).NotEmpty().WithMessage("Dish Name is required!");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required!");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("You must enter postive number for the price!");
        RuleFor(x => x.KiloCalories).GreaterThan(0).WithMessage("You must enter postive number for the calories");
    }
}
