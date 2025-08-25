using MediatR;
using Application.Contracts;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;
using AutoMapper;
using Domain.Models; // Make sure this is added to get the full User model

namespace Application.CQRS.Users.Queries.GetUserByUsername
{
    // The handler must return a 'User' model, not a 'UserDto'.
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, User>
    {
        private readonly IUserRepository _userRepository;
        // IMapper is not needed here since we are returning the full model.
        // If you need to map to a DTO later for a different use case, you can keep it.
        // For this specific login scenario, it is not required.
        // private readonly IMapper _mapper;

        public GetUserByUsernameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            // _mapper = mapper;
        }

        public async Task<User> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsername(request.Username);
            if (user == null)
            {
                // It's better not to throw a NotFoundException for login,
                // as it can reveal whether a username exists or not.
                // It is better to return null.
                return null;
            }
            // Return the full user object, which contains the password.
            return user;
        }
    }
}