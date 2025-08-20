// Application/CQRS/Invoices/Commands/CreateInvoiceCommand.cs
using Application.Responses;
using MediatR;
using Application.DTOs.Invoices;

namespace Application.CQRS.Invoices.Commands
{
    public class CreateInvoiceCommand : IRequest<BaseCommandResponse>
    {
        public CreateInvoiceDto InvoiceDto { get; set; }
    }
}