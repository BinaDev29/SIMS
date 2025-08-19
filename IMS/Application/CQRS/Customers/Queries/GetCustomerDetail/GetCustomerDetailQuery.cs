using MediatR;
using Application.DTOs.Customers;

namespace Application.CQRS.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery : IRequest<CustomerDto>
    {
        public required int Id { get; set; }
    }
}