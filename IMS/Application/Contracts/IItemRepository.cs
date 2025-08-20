using Domain.Models;
using Application.Contracts;

namespace Application.Contracts
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        // Add any specific methods for Item here
    }
}