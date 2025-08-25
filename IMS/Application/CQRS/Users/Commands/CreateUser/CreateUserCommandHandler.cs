using Application.Responses; // Namespace corrected
using Application.Contracts;
using Application.DTOs.Users.Validators; // New using for validation
using BCrypt.Net;
using Domain.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            // Add validation
            var validator = new CreateUserDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UserDto, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var existingUser = await _userRepository.GetByUsername(request.UserDto.Username);
            if (existingUser != null)
            {
                response.Success = false;
                response.Message = "Username already exists.";
                return response;
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.UserDto.Password);

            var newUser = new User
            {
                Username = request.UserDto.Username,
                Password = hashedPassword,
                Role = request.UserDto.Role
            };

            var createdUser = await _userRepository.AddAsync(newUser, cancellationToken);

            response.Success = true;
            response.Message = "User registered successfully.";
            response.Id = createdUser.Id;
            return response;
        }
    }
}