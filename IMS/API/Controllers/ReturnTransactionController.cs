using Application.CQRS.ReturnTransactions.Commands.CreateReturnTransaction;
using Application.CQRS.ReturnTransactions.Commands.DeleteReturnTransaction;
using Application.CQRS.ReturnTransactions.Commands.UpdateReturnTransaction;
using Application.CQRS.ReturnTransactions.Queries.GetReturnTransactionDetail;
using Application.CQRS.ReturnTransactions.Queries.GetReturnTransactionsList;
using Application.DTOs.ReturnTransactions;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ReturnTransactionController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ReturnTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ReturnTransactionDto>>> Get()
        {
            var query = new GetReturnTransactionsListQuery();
            var returnTransactions = await _mediator.Send(query);
            return Ok(returnTransactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnTransactionDto>> Get(int id)
        {
            var query = new GetReturnTransactionDetailQuery { Id = id };
            var returnTransaction = await _mediator.Send(query);
            return Ok(returnTransaction);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateReturnTransactionDto createReturnTransactionDto)
        {
            var command = new CreateReturnTransactionCommand { ReturnTransactionDto = createReturnTransactionDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateReturnTransactionDto updateReturnTransactionDto)
        {
            var command = new UpdateReturnTransactionCommand { ReturnTransactionDto = updateReturnTransactionDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteReturnTransactionCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}