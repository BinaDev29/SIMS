using Application.Responses; // Namespace corrected
using Application.Contracts;
using Application.DTOs.Suppliers.Validators; // New using for validation
using Application.Exceptions;
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Linq; // New using for validation
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Supplier.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, BaseCommandResponse>
    {
        private readonly ISupplierRepository _supplierRepository; // Changed to specific repository
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper) // Changed to specific repository
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            // Add validation
            var validator = new UpdateSupplierDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SupplierDto, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var supplierToUpdate = await _supplierRepository.GetByIdAsync(request.SupplierDto.Id, cancellationToken);

            if (supplierToUpdate == null)
            {
                response.Success = false;
                response.Message = "Supplier not found.";
                return response;
            }

            _mapper.Map(request.SupplierDto, supplierToUpdate);
            await _supplierRepository.UpdateAsync(supplierToUpdate, cancellationToken);

            response.Success = true;
            response.Message = "Supplier Updated Successfully";
            return response;
        }
    }
}