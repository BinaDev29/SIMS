using Application.Contracts;
using Domain.Models;
using Persistence;
using Persistence.Repositories;

namespace Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SIMSDbContext context) : base(context)
        {
        }
    }
}