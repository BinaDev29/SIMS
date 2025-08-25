using FluentValidation;
using Application.DTOs.Customers;

namespace Application.DTOs.Customers.Validators
{
    public class UpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerDtoValidator()
        {
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.ContactPerson).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("{PropertyName} is required.")
                .EmailAddress().WithMessage("{PropertyName} must be a valid email address.");
            RuleFor(p => p.Address).NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}