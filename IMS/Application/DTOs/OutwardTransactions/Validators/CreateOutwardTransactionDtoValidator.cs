using System;
using FluentValidation;
using Application.DTOs.OutwardTransactions;

namespace Application.DTOs.OutwardTransactions.Validators
{
    public class CreateOutwardTransactionDtoValidator : AbstractValidator<CreateOutwardTransactionDto>
    {
        public CreateOutwardTransactionDtoValidator()
        {
            RuleFor(p => p.ItemId).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.GodownId).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.CustomerId).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Quantity)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");
            RuleFor(p => p.UnitPrice)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");
            RuleFor(p => p.TransactionDate).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}