using MediatR;
using Application.DTOs.Suppliers;

namespace Application.CQRS.Supplier.Queries.GetSupplierDetail
{
    public class GetSupplierDetailQuery : IRequest<SupplierDto>
    {
        public required int Id { get; set; }
    }
}