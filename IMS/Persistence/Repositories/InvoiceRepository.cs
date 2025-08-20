// Persistence/Repositories/InvoiceRepository.cs
using Application.Contracts;
using Domain.Models;
using Persistence;

namespace Persistence.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(SIMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}