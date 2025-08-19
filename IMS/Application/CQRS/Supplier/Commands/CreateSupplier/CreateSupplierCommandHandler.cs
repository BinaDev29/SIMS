// -------------------------------------------------------------
// Application/CQRS/Supplier/Commands/CreateSupplier/CreateSupplierCommandHandler.cs
// -------------------------------------------------------------
using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.Responses;
using Domain.Models; // Make sure this is present
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Supplier.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<Domain.Models.Supplier> _supplierRepository; // Explicitly use Domain.Models.Supplier
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(IGenericRepository<Domain.Models.Supplier> supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var supplier = _mapper.Map<Domain.Models.Supplier>(request.SupplierDto);
            await _supplierRepository.AddAsync(supplier);
            response.Success = true;
            response.Message = "Supplier Created Successfully";
            return response;
        }
    }
}