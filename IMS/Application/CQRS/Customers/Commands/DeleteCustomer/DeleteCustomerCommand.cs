using MediatR;
using Application.Responses;

namespace Application.CQRS.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}