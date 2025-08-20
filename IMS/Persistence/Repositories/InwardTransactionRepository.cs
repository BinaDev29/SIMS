using Application.Contracts;
using Domain.Models;
using Persistence; // Corrected using directive

namespace Persistence.Repositories
{
    public class InwardTransactionRepository : GenericRepository<InwardTransaction>, IInwardTransactionRepository
    {
        public InwardTransactionRepository(SIMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}