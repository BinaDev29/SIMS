using MediatR;
using Application.DTOs.Customers;
using System.Collections.Generic;

namespace Application.CQRS.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<IReadOnlyList<CustomerDto>>
    {

    }
}