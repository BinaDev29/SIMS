using Application.Contracts;
using Domain.Models;
using Persistence;

namespace Persistence.Repositories
{
    public class ReturnTransactionRepository : GenericRepository<ReturnTransaction>, IReturnTransactionRepository
    {
        public ReturnTransactionRepository(SIMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}