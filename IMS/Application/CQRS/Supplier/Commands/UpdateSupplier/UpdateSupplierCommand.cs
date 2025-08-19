using MediatR;
using Application.DTOs.Suppliers;
using Application.Responses;

namespace Application.CQRS.Supplier.Commands.UpdateSupplier
{
    public class UpdateSupplierCommand : IRequest<BaseCommandResponse>
    {
        public required UpdateSupplierDto SupplierDto { get; set; }
    }
}