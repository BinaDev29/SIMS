using AutoMapper;
using MediatR;
using Application.Contracts;
using Application.DTOs.Users;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, IReadOnlyList<UserListDto>>
    {
        private readonly IUserRepository _userRepository; // Changed to IUserRepository
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler(IUserRepository userRepository, IMapper mapper) // Changed to IUserRepository
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<UserListDto>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IReadOnlyList<UserListDto>>(users);
        }
    }
}