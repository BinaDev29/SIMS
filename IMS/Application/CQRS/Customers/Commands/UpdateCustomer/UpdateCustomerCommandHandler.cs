using Application.Contracts;
using Application.Exceptions;
using Application.Responses;
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IGenericRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var customerToUpdate = await _customerRepository.GetByIdAsync(request.CustomerDto.Id, cancellationToken);

            if (customerToUpdate == null)
            {
                response.Success = false;
                response.Message = "Customer not found.";
                return response;
            }

            _mapper.Map(request.CustomerDto, customerToUpdate);

            // Passing the cancellation token
            await _customerRepository.UpdateAsync(customerToUpdate, cancellationToken);

            response.Success = true;
            response.Message = "Customer Updated Successfully";
            return response;
        }
    }
}