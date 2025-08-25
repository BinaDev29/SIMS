using Application.Responses; // Namespace corrected
using Application.Contracts;
using Application.Exceptions;
using Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Supplier.Commands.DeleteSupplier
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, BaseCommandResponse>
    {
        private readonly ISupplierRepository _supplierRepository; // Changed to specific repository

        public DeleteSupplierCommandHandler(ISupplierRepository supplierRepository) // Changed to specific repository
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var supplierToDelete = await _supplierRepository.GetByIdAsync(request.Id, cancellationToken);

            if (supplierToDelete == null)
            {
                response.Success = false;
                response.Message = "Supplier not found.";
                return response;
            }

            await _supplierRepository.DeleteAsync(supplierToDelete, cancellationToken);

            response.Success = true;
            response.Message = "Supplier Deleted Successfully";
            return response;
        }
    }
}