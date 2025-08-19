using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .GreaterThan(0);

            RuleFor(p => p.ItemId)
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.GodownId)
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.CustomerId)
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Quantity)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
            RuleFor(p => p.UnitPrice)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
            RuleFor(p => p.TransactionDate)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
