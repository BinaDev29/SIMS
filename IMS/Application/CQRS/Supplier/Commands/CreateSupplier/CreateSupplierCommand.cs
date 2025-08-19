// Application/CQRS/Supplier/Commands/CreateSupplier/CreateSupplierCommand.cs
using MediatR;
using Application.DTOs.Suppliers;
using Application.Responses;

namespace Application.CQRS.Supplier.Commands.CreateSupplier // Namespace corrected
{
    public class CreateSupplierCommand : IRequest<BaseCommandResponse>
    {
        public required CreateSupplierDto SupplierDto { get; set; }
    }
}