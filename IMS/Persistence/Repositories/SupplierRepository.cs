// Persistence/Repositories/SupplierRepository.cs
using Application.Contracts;
using Domain.Models;
using Persistence;

namespace Persistence.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(SIMSDbContext context) : base(context)
        {
        }
    }
}