using Application.Contracts;
using Application.DTOs.Employees;
using Application.DTOs.Users;
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Employees.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, EmployeeDto?>
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IGenericRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);
            if (employee == null)
            {
                return null;
            }
            return _mapper.Map<EmployeeDto>(employee);
        }
    }
}