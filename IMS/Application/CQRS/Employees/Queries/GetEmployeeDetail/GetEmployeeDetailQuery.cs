using MediatR;
using Application.DTOs.Employees;

namespace Application.CQRS.Employees.Queries.GetEmployeeDetail
{
    public class GetEmployeeDetailQuery : IRequest<EmployeeDto>
    {
        public required int Id { get; set; }
    }
}