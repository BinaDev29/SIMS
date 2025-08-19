using MediatR;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

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
            var customerToDelete = await _customerRepository.GetByIdAsync(request.Id);

            if (customerToDelete == null)
            {
                response.Success = false;
                response.Message = "Customer not found.";
                return response;
            }

            await _customerRepository.DeleteAsync(customerToDelete);

            response.Success = true;
            response.Message = "Customer Deleted Successfully";
            return response;
        }
    }
}