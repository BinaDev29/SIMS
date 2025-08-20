// API/Controllers/UsersController.cs
using Application.CQRS.Employees.Commands.CreateEmployee;
using Application.CQRS.Employees.Queries; // Corrected namespace
using Application.DTOs.Employees;
using Application.DTOs.Users;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var command = new CreateEmployeeCommand { EmployeeDto = createEmployeeDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var response = await _mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}