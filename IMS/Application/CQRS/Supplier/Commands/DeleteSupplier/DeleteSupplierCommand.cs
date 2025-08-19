using MediatR;
using Application.Responses;

namespace Application.CQRS.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}