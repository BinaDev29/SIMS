using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using Application.DTOs.Suppliers;

namespace Application.DTOs.Suppliers.Validators
{
    public class CreateSupplierDtoValidator : AbstractValidator<CreateSupplierDto>
    {
        public CreateSupplierDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.ContactPerson).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("{PropertyName} is required.")
                .EmailAddress().WithMessage("{PropertyName} must be a valid email address.");
            RuleFor(p => p.Address).NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}