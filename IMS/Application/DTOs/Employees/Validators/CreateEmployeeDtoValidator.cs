using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;
using Application.DTOs.Employees;

namespace Application.DTOs.Employees.Validators
{
    public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeDtoValidator()
        {
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Username).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Password).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("{PropertyName} is required.")
                .EmailAddress().WithMessage("{PropertyName} must be a valid email address.");
        }
    }
}