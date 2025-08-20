using Application.Contracts;
using Domain.Models;
using Persistence; 

namespace Persistence.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(SIMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}