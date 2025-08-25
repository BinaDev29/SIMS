// API/Controllers/RegisterController.cs
using Application.CQRS.Users.Commands.CreateUser;
using Application.DTOs.Users;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    // ከ ControllerBase ይልቅ BaseApiController እንዲወርስ አድርግ
    // [ApiController] እና [Route] attributeን አጥፋ ምክንያቱም BaseApiController ቀድሞውንም አለው
    public class RegisterController : BaseApiController
    {
        // IMediator ንብረቱን ከ BaseApiController ስለምትወርስ constructorም ሆነ የ _mediator ንብረቱን እንደገና መግለጽ አያስፈልግም

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Register([FromBody] RegisterDto registerDto)
        {
            // 1. Create a CreateUserDto object using the data from registerDto.
            var userDto = new CreateUserDto
            {
                Username = registerDto.Username,
                Password = registerDto.Password,
                Role = "User" // Or a role that fits your needs
            };

            // 2. Create the command and assign the userDto to its UserDto property.
            var command = new CreateUserCommand
            {
                UserDto = userDto
            };

            var response = await Mediator.Send(command);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}