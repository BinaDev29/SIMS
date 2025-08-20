// Persistence/Repositories/GodownRepository.cs
using Application.Contracts;
using Domain.Models;
using Persistence; // Correct using directive for SIMSDbContext

namespace Persistence.Repositories
{
    public class GodownRepository : GenericRepository<Godown>, IGodownRepository
    {
        public GodownRepository(SIMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}