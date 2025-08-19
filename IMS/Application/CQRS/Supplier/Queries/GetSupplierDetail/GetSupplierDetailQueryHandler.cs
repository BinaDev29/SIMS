using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.Suppliers;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.Supplier.Queries.GetSupplierDetail
{
    public class GetSupplierDetailQueryHandler : IRequestHandler<GetSupplierDetailQuery, SupplierDto>
    {
        private readonly IGenericRepository<Domain.Models.Supplier> _supplierRepository;
        private readonly IMapper _mapper;

        public GetSupplierDetailQueryHandler(IGenericRepository<Domain.Models.Supplier> supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<SupplierDto> Handle(GetSupplierDetailQuery request, CancellationToken cancellationToken)
        {
            var supplier = await _supplierRepository.GetByIdAsync(request.Id);
            if (supplier == null)
            {
                throw new NotFoundException(nameof(Supplier), request.Id);
            }
            return _mapper.Map<SupplierDto>(supplier);
        }
    }
}