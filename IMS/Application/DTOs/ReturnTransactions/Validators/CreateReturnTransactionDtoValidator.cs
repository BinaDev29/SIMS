using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Application.DTOs.ReturnTransactions;

namespace Application.DTOs.ReturnTransactions.Validators
{
    public class CreateReturnTransactionDtoValidator : AbstractValidator<CreateReturnTransactionDto>
    {
        public CreateReturnTransactionDtoValidator()
        {
            RuleFor(p => p.ItemId).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.GodownId).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.CustomerId).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Quantity).NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");
            RuleFor(p => p.Reason).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.TransactionDate).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}