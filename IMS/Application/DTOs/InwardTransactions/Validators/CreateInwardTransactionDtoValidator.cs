using System;
using FluentValidation;
using Application.DTOs.InwardTransactions;

namespace Application.DTOs.InwardTransactions.Validators
{
    public class CreateInwardTransactionDtoValidator : AbstractValidator<CreateInwardTransactionDto>
    {
        public CreateInwardTransactionDtoValidator()
        {
            RuleFor(p => p.ItemId).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.GodownId).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.SupplierId).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Quantity).NotEmpty().WithMessage("{PropertyName} is required.").GreaterThan(0);
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("{PropertyName} is required.").GreaterThan(0);
            RuleFor(p => p.TransactionDate).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}