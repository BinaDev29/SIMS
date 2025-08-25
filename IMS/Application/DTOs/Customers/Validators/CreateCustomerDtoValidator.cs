using FluentValidation;
using Application.DTOs.Customers;

namespace Application.DTOs.Customers.Validators
{
    public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.ContactPerson).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("{PropertyName} is required.")
                .EmailAddress().WithMessage("{PropertyName} must be a valid email address.");
            RuleFor(p => p.Address).NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}