using Application.CQRS.Employees.Commands.CreateEmployee;
using Application.CQRS.Employees.Commands.DeleteEmployee;
using Application.CQRS.Employees.Commands.UpdateEmployee;
using Application.CQRS.Employees.Queries.GetEmployeeDetail;
using Application.CQRS.Employees.Queries.GetEmployeesList;
using Application.DTOs.Employees;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EmployeeDto>>> Get()
        {
            var query = new GetEmployeesListQuery();
            var employees = await _mediator.Send(query);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            var query = new GetEmployeeDetailQuery { Id = id };
            var employee = await _mediator.Send(query);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var command = new CreateEmployeeCommand { EmployeeDto = createEmployeeDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            var command = new UpdateEmployeeCommand { EmployeeDto = updateEmployeeDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteEmployeeCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}