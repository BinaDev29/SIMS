// Application/CQRS/Employees/Commands/CreateEmployee/CreateEmployeeCommandHandler.cs
using Application.Contracts;
using Application.DTOs.Employees.Validators;
using Application.DTOs.Users;
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
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IGenericRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            // Pass the cancellationToken to ValidateAsync
            var validator = new CreateEmployeeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EmployeeDto, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var employee = _mapper.Map<Employee>(request.EmployeeDto);
            employee.Password = BCrypt.Net.BCrypt.HashPassword(request.EmployeeDto.Password);

            await _employeeRepository.AddAsync(employee);

            response.Success = true;
            response.Message = "Employee Created Successfully";
            response.Id = employee.Id;

            return response;
        }
    }
}