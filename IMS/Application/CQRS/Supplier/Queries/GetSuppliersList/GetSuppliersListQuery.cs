using MediatR;
using Application.DTOs.Suppliers;
using System.Collections.Generic;

namespace Application.CQRS.Supplier.Queries.GetSuppliersList
{
    // Make sure the class is public
    public class GetSuppliersListQuery : IRequest<IReadOnlyList<SupplierDto>>
    {

    }
}