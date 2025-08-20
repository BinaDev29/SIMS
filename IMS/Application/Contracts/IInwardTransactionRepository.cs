using Domain.Models;
using Application.Contracts;

namespace Application.Contracts
{
    public interface IInwardTransactionRepository : IGenericRepository<InwardTransaction>
    {
        // Add any specific methods for InwardTransaction here
    }
}