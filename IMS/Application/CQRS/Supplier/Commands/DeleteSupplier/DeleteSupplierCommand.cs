using MediatR;
using Application.Responses;

namespace Application.CQRS.Supplier.Commands.DeleteSupplier
{
    public class DeleteSupplierCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}