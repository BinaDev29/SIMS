using MediatR;
using Application.DTOs.Employees;
using System.Collections.Generic;

namespace Application.CQRS.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQuery : IRequest<IReadOnlyList<EmployeeDto>>
    {

    }
}