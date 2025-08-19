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
        private readonly IGenericRepository<Domain.Models.Supplier> _supplierRepository;
        private readonly IMapper _mapper;

        public GetSuppliersListQueryHandler(IGenericRepository<Domain.Models.Supplier> supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<SupplierDto>> Handle(GetSuppliersListQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _supplierRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<SupplierDto>>(suppliers);
        }
    }
}