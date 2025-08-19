using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using Application.DTOs.InwardTransactions;

namespace Application.DTOs.InwardTransactions.Validators
{
    public class UpdateInwardTransactionDtoValidator : AbstractValidator<UpdateInwardTransactionDto>
    {
        public UpdateInwardTransactionDtoValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be a non-negative value.");

            RuleFor(p => p.ItemId)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.GodownId)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.SupplierId)
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