using FluentValidation;
using Application.DTOs.Users;

namespace Application.DTOs.Users.Validators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("Id must be a positive value.");

            RuleFor(p => p.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MaximumLength(50).WithMessage("Username cannot exceed 50 characters.");

            RuleFor(p => p.Role)
                .NotEmpty().WithMessage("Role is required.");
        }
    }
}