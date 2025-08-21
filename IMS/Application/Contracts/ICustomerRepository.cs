using Application.Contracts;
using Domain.Models;

namespace Application.Contracts
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}