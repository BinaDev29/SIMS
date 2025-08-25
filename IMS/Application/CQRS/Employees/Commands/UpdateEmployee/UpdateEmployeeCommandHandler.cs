using Application.Responses; // Namespace updated
using Application.Contracts;
using Application.Exceptions;
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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
            var employeeToUpdate = await _employeeRepository.GetByIdAsync(request.EmployeeDto.Id, cancellationToken);

            if (employeeToUpdate == null)
            {
                response.Success = false;
                response.Message = "Employee not found.";
                return response;
            }

            _mapper.Map(request.EmployeeDto, employeeToUpdate);
            await _employeeRepository.UpdateAsync(employeeToUpdate, cancellationToken);

            response.Success = true;
            response.Message = "Employee Updated Successfully";
            return response;
        }
    }
}