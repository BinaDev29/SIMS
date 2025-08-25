using FluentValidation;
using Application.DTOs.Godowns;

namespace Application.DTOs.Godowns.Validators
{
    public class CreateGodownDtoValidator : AbstractValidator<CreateGodownDto>
    {
        public CreateGodownDtoValidator()
        {
            RuleFor(p => p.GodownName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Location)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.GodownManager)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}