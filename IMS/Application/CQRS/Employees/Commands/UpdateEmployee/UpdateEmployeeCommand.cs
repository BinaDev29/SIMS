using MediatR;
using Application.DTOs.Employees;
using Application.Responses;

namespace Application.CQRS.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<BaseCommandResponse>
    {
        public required UpdateEmployeeDto EmployeeDto { get; set; }
    }
}