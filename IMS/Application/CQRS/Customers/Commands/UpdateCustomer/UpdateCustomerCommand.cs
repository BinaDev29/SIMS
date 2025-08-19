using MediatR;
using Application.DTOs.Customers;
using Application.Responses;

namespace Application.CQRS.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<BaseCommandResponse>
    {
        public required UpdateCustomerDto CustomerDto { get; set; }
    }
}