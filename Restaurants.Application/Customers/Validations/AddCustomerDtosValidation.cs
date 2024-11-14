using FluentValidation;
using Restaurants.Application.Customers.Dtos;

namespace Restaurants.Application.Customers.Validations; 
public class AddCustomerDtosValidation  : AbstractValidator<AddCustomer>{

    public AddCustomerDtosValidation() {

        RuleFor(dto => dto.FirstName)
            .NotEmpty().WithMessage("First Name is required!");
        RuleFor(dto => dto.FirstName)
            .Length(3, 20)
            .WithMessage("The first name must be between 3 and 20 characters long. Please enter a valid first name");
        RuleFor(dto => dto.LastName)
            .NotEmpty().WithMessage("Last Name is Required!");
        RuleFor(dto => dto.LastName)
            .Length(3, 20)
            .WithMessage("The last name must be between 3 and 20 characters long. Please enter a valid last name");
        RuleFor(dto => dto.Email)
            .EmailAddress()
            .WithMessage("Please provide a valid email address!");
        RuleFor(dto => dto.PhoneNumber)
            .Matches(@"^05\d{8}$")
            .WithMessage("Invalid phone number. Please enter a 10-digit Saudi phone number starting with '05'.");

    }
}
