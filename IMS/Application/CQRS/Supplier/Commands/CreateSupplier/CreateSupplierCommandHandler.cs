using Application.Responses; // Namespace corrected
using Application.Contracts;
using Application.DTOs.Suppliers.Validators; // New using for validation
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Linq; // New using for validation
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Supplier.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, BaseCommandResponse>
    {
        private readonly ISupplierRepository _supplierRepository; // Changed to specific repository
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(ISupplierRepository supplierRepository, IMapper mapper) // Changed to specific repository
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            // Add validation
            var validator = new CreateSupplierDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SupplierDto, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var supplier = _mapper.Map<Domain.Models.Supplier>(request.SupplierDto);
            await _supplierRepository.AddAsync(supplier, cancellationToken);

            response.Success = true;
            response.Message = "Supplier Created Successfully";
            response.Id = supplier.Id; // Add the new supplier's ID to the response

            return response;
        }
    }
}