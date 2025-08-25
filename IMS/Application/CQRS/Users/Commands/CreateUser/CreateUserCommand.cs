// Application/CQRS/Users/Commands/CreateUser
using Application.DTOs.Users;
using Application.Responses;
using MediatR;

namespace Application.CQRS.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<BaseCommandResponse>
    {
        public required CreateUserDto UserDto { get; set; }
    }
}