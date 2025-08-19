using MediatR;
using Application.DTOs.Customers;
using Application.Responses;

namespace Application.CQRS.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<BaseCommandResponse>
    {
        public required CreateCustomerDto CustomerDto { get; set; }
    }
}