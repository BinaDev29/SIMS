using Microsoft.AspNetCore.Mvc;
using API.Auth;
using Application.DTOs.Users;
using Application.Responses;
using MediatR;
using Application.CQRS.Users.Queries;
using System.Threading.Tasks;
using BCrypt.Net;

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

            var user = await _mediator.Send(new GetUserByUsernameQuery(loginDto.Username));

            // Verify the entered password against the hashed password in the database
            if (user != null && BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                var token = _tokenGenerator.GenerateToken(user.Username, user.Role);
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