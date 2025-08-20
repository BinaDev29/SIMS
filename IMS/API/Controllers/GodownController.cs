using Application.CQRS.Godowns.Commands.CreateGodown;
using Application.CQRS.Godowns.Commands.DeleteGodown;
using Application.CQRS.Godowns.Commands.UpdateGodown;
using Application.CQRS.Godowns.Queries.GetGodownDetail;
using Application.CQRS.Godowns.Queries.GetGodownsList;
using Application.DTOs.Godowns;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GodownController : BaseApiController
    {
        private readonly IMediator _mediator;

        public GodownController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<GodownDto>>> Get()
        {
            var query = new GetGodownsListQuery();
            var godowns = await _mediator.Send(query);
            return Ok(godowns);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GodownDto>> Get(int id)
        {
            var query = new GetGodownDetailQuery { Id = id };
            var godown = await _mediator.Send(query);
            return Ok(godown);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateGodownDto createGodownDto)
        {
            var command = new CreateGodownCommand { GodownDto = createGodownDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateGodownDto updateGodownDto)
        {
            var command = new UpdateGodownCommand { GodownDto = updateGodownDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteGodownCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}