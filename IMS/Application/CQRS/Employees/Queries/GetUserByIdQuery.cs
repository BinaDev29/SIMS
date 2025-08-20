// Application/CQRS/Employees/Queries/GetUserByIdQuery.cs
using Application.DTOs.Employees;
using Application.DTOs.Users;
using MediatR;

namespace Application.CQRS.Employees.Queries
{
    public class GetUserByIdQuery : IRequest<EmployeeDto?>
    {
        public int Id { get; set; }
    }
}