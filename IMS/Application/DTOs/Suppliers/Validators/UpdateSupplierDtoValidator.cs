using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using Application.DTOs.Suppliers;

namespace Application.DTOs.Suppliers.Validators
{
    public class UpdateSupplierDtoValidator : AbstractValidator<UpdateSupplierDto>
    {
        public UpdateSupplierDtoValidator()
        {
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be a non-negative value.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.ContactPerson).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("{PropertyName} is required.")
                .EmailAddress().WithMessage("{PropertyName} must be a valid email address.");
            RuleFor(p => p.Address).NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}