using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IGenericRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var employeeToUpdate = await _employeeRepository.GetByIdAsync(request.EmployeeDto.Id);

            if (employeeToUpdate == null)
            {
                response.Success = false;
                response.Message = "Employee not found.";
                return response;
            }

            _mapper.Map(request.EmployeeDto, employeeToUpdate);
            await _employeeRepository.UpdateAsync(employeeToUpdate);

            response.Success = true;
            response.Message = "Employee Updated Successfully";
            return response;
        }
    }
}