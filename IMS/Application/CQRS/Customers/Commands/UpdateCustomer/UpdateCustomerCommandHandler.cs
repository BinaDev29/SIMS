using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

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
            var customerToUpdate = await _customerRepository.GetByIdAsync(request.CustomerDto.Id);

            if (customerToUpdate == null)
            {
                response.Success = false;
                response.Message = "Customer not found.";
                return response;
            }

            _mapper.Map(request.CustomerDto, customerToUpdate);
            await _customerRepository.UpdateAsync(customerToUpdate);

            response.Success = true;
            response.Message = "Customer Updated Successfully";
            return response;
        }
    }
}