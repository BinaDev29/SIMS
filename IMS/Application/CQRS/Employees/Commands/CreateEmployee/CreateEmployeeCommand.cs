using MediatR;
using Application.DTOs.Employees;
using Application.Responses;

namespace Application.CQRS.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<BaseCommandResponse>
    {
        public required CreateEmployeeDto EmployeeDto { get; set; }
    }
}