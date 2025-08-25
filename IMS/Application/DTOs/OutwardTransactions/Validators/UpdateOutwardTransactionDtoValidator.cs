using System;
using FluentValidation;
using Application.DTOs.OutwardTransactions;

namespace Application.DTOs.OutwardTransactions.Validators
{
    public class UpdateOutwardTransactionDtoValidator : AbstractValidator<UpdateOutwardTransactionDto>
    {
        public UpdateOutwardTransactionDtoValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.ItemId).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.GodownId).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.CustomerId).NotEmpty().WithMessage("{PropertyName} is required.");

            // የተስተካከለው የ QuantityDelivered ንብረት
            RuleFor(p => p.QuantityDelivered)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");

            RuleFor(p => p.UnitPrice)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");

            // የተስተካከለው የ OutwardDate ንብረት
            RuleFor(p => p.OutwardDate).NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}