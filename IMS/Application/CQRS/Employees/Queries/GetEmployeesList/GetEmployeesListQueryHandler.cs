using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.Employees;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeesListQuery, IReadOnlyList<EmployeeDto>>
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeesListQueryHandler(IGenericRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<EmployeeDto>> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<EmployeeDto>>(employees);
        }
    }
}