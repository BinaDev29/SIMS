using MediatR;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.Supplier.Commands.DeleteSupplier
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<Domain.Models.Supplier> _supplierRepository;

        public DeleteSupplierCommandHandler(IGenericRepository<Domain.Models.Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var supplierToDelete = await _supplierRepository.GetByIdAsync(request.Id);

            if (supplierToDelete == null)
            {
                response.Success = false;
                response.Message = "Supplier not found.";
                return response;
            }

            await _supplierRepository.DeleteAsync(supplierToDelete);

            response.Success = true;
            response.Message = "Supplier Deleted Successfully";
            return response;
        }
    }
}