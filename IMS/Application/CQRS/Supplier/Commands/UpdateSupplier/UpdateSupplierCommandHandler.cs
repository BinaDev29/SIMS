using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.Supplier.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<Domain.Models.Supplier> _supplierRepository;
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(IGenericRepository<Domain.Models.Supplier> supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var supplierToUpdate = await _supplierRepository.GetByIdAsync(request.SupplierDto.Id);

            if (supplierToUpdate == null)
            {
                response.Success = false;
                response.Message = "Supplier not found.";
                return response;
            }

            _mapper.Map(request.SupplierDto, supplierToUpdate);
            await _supplierRepository.UpdateAsync(supplierToUpdate);

            response.Success = true;
            response.Message = "Supplier Updated Successfully";
            return response;
        }
    }
}