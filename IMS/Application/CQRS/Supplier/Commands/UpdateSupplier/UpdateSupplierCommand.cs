using MediatR;
using Application.DTOs.Suppliers;
using Application.Responses;

namespace Application.CQRS.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommand : IRequest<BaseCommandResponse>
    {
        public required UpdateSupplierDto SupplierDto { get; set; }
    }
}