using Application.Contracts;
using Application.Exceptions;
using Application.Responses;
using Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<Customer> _customerRepository;

        public DeleteCustomerCommandHandler(IGenericRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var customerToDelete = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);

            if (customerToDelete == null)
            {
                response.Success = false;
                response.Message = "Customer not found.";
                return response;
            }

            // Passing the cancellation token
            await _customerRepository.DeleteAsync(customerToDelete, cancellationToken);

            response.Success = true;
            response.Message = "Customer Deleted Successfully";
            return response;
        }
    }
}