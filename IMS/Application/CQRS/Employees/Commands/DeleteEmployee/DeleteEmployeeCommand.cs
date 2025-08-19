using MediatR;
using Application.Responses;

namespace Application.CQRS.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}