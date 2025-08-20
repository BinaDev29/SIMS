// Application/CQRS/Users/Queries/GetUsersListQueryHandler.cs
using AutoMapper;
using MediatR;
using Application.Contracts;
using Application.DTOs.Users;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Users.Queries
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, IReadOnlyList<UserListDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<UserListDto>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var users = await _employeeRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<UserListDto>>(users);
        }
    }
}