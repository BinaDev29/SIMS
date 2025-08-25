using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.Suppliers;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Supplier.Queries.GetSuppliersList
{
    public class GetSuppliersListQueryHandler : IRequestHandler<GetSuppliersListQuery, IReadOnlyList<SupplierDto>>
    {
        private readonly ISupplierRepository _supplierRepository; // Changed to specific repository
        private readonly IMapper _mapper;

        public GetSuppliersListQueryHandler(ISupplierRepository supplierRepository, IMapper mapper) // Changed to specific repository
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<SupplierDto>> Handle(GetSuppliersListQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IReadOnlyList<SupplierDto>>(suppliers);
        }
    }
}