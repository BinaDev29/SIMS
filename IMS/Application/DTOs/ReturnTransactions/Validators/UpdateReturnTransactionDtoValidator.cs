using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using Application.DTOs.ReturnTransactions;

namespace Application.DTOs.ReturnTransactions.Validators
{
    public class UpdateReturnTransactionDtoValidator : AbstractValidator<UpdateReturnTransactionDto>
    {
        public UpdateReturnTransactionDtoValidator()
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
            RuleFor(p => p.Reason)
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.TransactionDate)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}