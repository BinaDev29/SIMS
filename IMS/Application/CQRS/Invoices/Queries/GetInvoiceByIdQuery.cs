using Application.DTOs.Invoices;
using MediatR;

namespace Application.CQRS.Invoices.Queries
{
    public class GetInvoiceByIdQuery : IRequest<InvoiceDto?>
    {
        public int Id { get; set; }
    }
}