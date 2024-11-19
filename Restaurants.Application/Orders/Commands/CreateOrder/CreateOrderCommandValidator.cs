using FluentValidation;

namespace Restaurants.Application.Orders.Commands.CreateOrder; 
public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand> {

    public CreateOrderCommandValidator() {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Customer ID is required.");
        RuleFor(x => x.OrderDate)
            .NotEmpty()
            .GreaterThan(DateTime.Now).WithMessage("Order date must be in the future.")
            .LessThan(DateTime.Now.AddYears(1)).WithMessage("Event date cannot be more than a year in the future.");
        RuleFor(x => x.OrderStatus)
            .NotEmpty().WithMessage("Order status is required.")
            .Must(status => new[] { "Pending", "Approved", "Rejected", "Delivered" }.Contains(status))
            .WithMessage("Order status must be one of the following: Pending, Approved, Rejected, or Delivered.");
        RuleFor(x => x.TotalAmount)
            .NotEmpty().WithMessage("Order total amount is required.")
            .GreaterThan(0).WithMessage("Total amount must be greater than zero.")
            .LessThanOrEqualTo(10000).WithMessage("Total amount cannot exceed 10,000.");
    }
}
