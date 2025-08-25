// API/Controllers/LoginController.cs
using Microsoft.AspNetCore.Mvc;
using API.Auth;
using Application.DTOs.Users;
using Application.Responses;
using MediatR;
using Application.CQRS.Users.Queries.GetUserByUsername;
using System.Threading.Tasks;
using BCrypt.Net;

namespace API.Controllers
{
    // ከ ControllerBase ይልቅ BaseApiController እንዲወርስ አድርግ
    // [ApiController] እና [Route] attributeን አጥፋ ምክንያቱም BaseApiController ቀድሞውንም አለው
    public class LoginController : BaseApiController
    {
        private readonly JwtTokenGenerator _tokenGenerator;

        // Mediator የሚለውን ንብረት ከ BaseApiController ስለምትወርስ እዚህ አያስፈልግም
        public LoginController(JwtTokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Login([FromBody] LoginDto loginDto)
        {
            var response = new BaseCommandResponse();

            var user = await Mediator.Send(new GetUserByUsernameQuery(loginDto.Username));

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