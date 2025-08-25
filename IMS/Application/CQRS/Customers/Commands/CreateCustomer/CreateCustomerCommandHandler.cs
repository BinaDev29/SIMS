using Application.Contracts;
using Application.Responses;
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IGenericRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var customer = _mapper.Map<Customer>(request.CustomerDto);

            // Passing the cancellation token
            var createdCustomer = await _customerRepository.AddAsync(customer, cancellationToken);

            response.Success = true;
            response.Message = "Customer Created Successfully";
            response.Id = createdCustomer.Id; // Returning the ID of the new customer

            return response;
        }
    }
}