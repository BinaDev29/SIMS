// Application/CQRS/Users/Queries/GetUserByUsernameQueryHandler.cs
using MediatR;
using Domain.Models;
using Application.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Users.Queries
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetUserByUsernameQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            // Here you need a method to get a user by username from the repository
            var user = await _employeeRepository.GetByUsername(request.Username);
            return user;
        }
    }
}