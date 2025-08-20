using FluentValidation;
using Application.DTOs.Invoices;

namespace Application.DTOs.Invoices.Validators
{
    public class CreateInvoiceDtoValidator : AbstractValidator<CreateInvoiceDto>
    {
        public CreateInvoiceDtoValidator()
        {
            RuleFor(p => p.CustomerId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.InvoiceDetails)
                .NotNull().WithMessage("Invoice must have at least one item.")
                .Must(list => list.Count > 0).WithMessage("Invoice must have at least one item.");

            RuleForEach(x => x.InvoiceDetails).SetValidator(new CreateInvoiceDetailDtoValidator());
        }
    }

    public class CreateInvoiceDetailDtoValidator : AbstractValidator<CreateInvoiceDetailDto>
    {
        public CreateInvoiceDetailDtoValidator()
        {
            RuleFor(p => p.ItemId)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Quantity)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.");
        }
    }
}