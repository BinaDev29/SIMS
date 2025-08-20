// Application/Contracts/IInvoiceRepository.cs
using Domain.Models;

namespace Application.Contracts
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
    }
}