using FluentValidation;
using Application.DTOs.Items;

namespace Application.DTOs.Items.Validators
{
    public class UpdateItemDtoValidator : AbstractValidator<UpdateItemDto>
    {
        public UpdateItemDtoValidator()
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("{PropertyName} must be a positive value.");

            RuleFor(p => p.ItemName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.StockQuantity)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be a non-negative value.");

            RuleFor(p => p.GodownId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");

            RuleFor(p => p.UnitPrice)
                .NotNull().When(p => p.UnitPrice.HasValue)
                .GreaterThanOrEqualTo(0).When(p => p.UnitPrice.HasValue).WithMessage("{PropertyName} must be a non-negative value.");
        }
    }
}