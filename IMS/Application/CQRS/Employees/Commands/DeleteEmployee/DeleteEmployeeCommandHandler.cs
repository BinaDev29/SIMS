using MediatR;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

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
            var employeeToDelete = await _employeeRepository.GetByIdAsync(request.Id);

            if (employeeToDelete == null)
            {
                response.Success = false;
                response.Message = "Employee not found.";
                return response;
            }

            await _employeeRepository.DeleteAsync(employeeToDelete);

            response.Success = true;
            response.Message = "Employee Deleted Successfully";
            return response;
        }
    }
}