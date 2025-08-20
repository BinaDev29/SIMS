using Microsoft.AspNetCore.Mvc;
using API.Auth;
using Application.DTOs.Users;
using Application.Responses;
using MediatR;
using Application.CQRS.Users.Queries;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtTokenGenerator _tokenGenerator;

        public LoginController(IMediator mediator, JwtTokenGenerator tokenGenerator)
        {
            _mediator = mediator;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Login([FromBody] LoginDto loginDto)
        {
            var response = new BaseCommandResponse();

            // Query the database to find the user by username
            var user = await _mediator.Send(new GetUserByUsernameQuery(loginDto.Username));

            // Check if the user exists and the password is correct
            if (user != null && user.Password == loginDto.Password)
            {
                var token = _tokenGenerator.GenerateToken(user.Username, user.Role); // Pass role for claims
                response.Success = true;
                response.Message = $"Login Successful. Token: {token}";
                return Ok(response);
            }
            else
            {
                response.Success = false;
                response.Message = "Invalid username or password.";
                return Unauthorized(response);
            }
        }
    }
}