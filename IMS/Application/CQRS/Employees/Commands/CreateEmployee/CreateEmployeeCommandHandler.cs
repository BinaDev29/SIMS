using Application.Contracts;
using Application.DTOs.Employees.Validators;
using Application.Responses;
using AutoMapper;
using BCrypt.Net;
using Domain.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseCommandResponse>
    {
        // Changed to IEmployeeRepository
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateEmployeeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EmployeeDto, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            // Check if username already exists using the specific repository method
            var existingUser = await _employeeRepository.GetByUsername(request.EmployeeDto.Username);
            if (existingUser != null)
            {
                response.Success = false;
                response.Message = "Username already exists.";
                return response;
            }

            var employee = _mapper.Map<Employee>(request.EmployeeDto);
            employee.Password = BCrypt.Net.BCrypt.HashPassword(request.EmployeeDto.Password);

            // Passing the cancellation token
            var createdEmployee = await _employeeRepository.AddAsync(employee, cancellationToken);

            response.Success = true;
            response.Message = "Employee Created Successfully";
            response.Id = createdEmployee.Id;

            return response;
        }
    }
}