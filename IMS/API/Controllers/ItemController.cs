using Application.CQRS.Items.Commands.CreateItem;
using Application.CQRS.Items.Commands.DeleteItem;
using Application.CQRS.Items.Commands.UpdateItem;
using Application.CQRS.Items.Queries.GetItemDetail;
using Application.CQRS.Items.Queries.GetItemsList;
using Application.DTOs.Items;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ItemController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ItemDto>>> Get()
        {
            var query = new GetItemsListQuery();
            var items = await _mediator.Send(query);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> Get(int id)
        {
            var query = new GetItemDetailQuery { Id = id };
            var item = await _mediator.Send(query);
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateItemDto createItemDto)
        {
            var command = new CreateItemCommand { ItemDto = createItemDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateItemDto updateItemDto)
        {
            var command = new UpdateItemCommand { ItemDto = updateItemDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteItemCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}