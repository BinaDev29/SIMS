using Application.Contracts;
using Application.Exceptions;
using Application.Responses;
using Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<Employee> _employeeRepository;

        public DeleteEmployeeCommandHandler(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            // Passing the cancellation token
            var employeeToDelete = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (employeeToDelete == null)
            {
                response.Success = false;
                response.Message = "Employee not found.";
                return response;
            }

            // Passing the cancellation token
            await _employeeRepository.DeleteAsync(employeeToDelete, cancellationToken);

            response.Success = true;
            response.Message = "Employee Deleted Successfully";
            return response;
        }
    }
}