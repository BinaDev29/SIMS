// Persistence/Repositories/InvoiceDetailRepository.cs
using Application.Contracts;
using Domain.Models;
using Persistence;

namespace Persistence.Repositories
{
    public class InvoiceDetailRepository : GenericRepository<InvoiceDetail>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(SIMSDbContext dbContext) : base(dbContext)
        {
        }
    }
}