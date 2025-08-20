using Application.CQRS.OutwardTransactions.Commands.CreateOutwardTransaction;
using Application.CQRS.OutwardTransactions.Commands.DeleteOutwardTransaction;
using Application.CQRS.OutwardTransactions.Commands.UpdateOutwardTransaction;
using Application.CQRS.OutwardTransactions.Queries.GetOutwardTransactionDetail;
using Application.CQRS.OutwardTransactions.Queries.GetOutwardTransactionsList;
using Application.DTOs.OutwardTransactions;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OutwardTransactionController : BaseApiController
    {
        private readonly IMediator _mediator;

        public OutwardTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OutwardTransactionDto>>> Get()
        {
            var query = new GetOutwardTransactionsListQuery();
            var outwardTransactions = await _mediator.Send(query);
            return Ok(outwardTransactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OutwardTransactionDto>> Get(int id)
        {
            var query = new GetOutwardTransactionDetailQuery { Id = id };
            var outwardTransaction = await _mediator.Send(query);
            return Ok(outwardTransaction);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateOutwardTransactionDto createOutwardTransactionDto)
        {
            var command = new CreateOutwardTransactionCommand { OutwardTransactionDto = createOutwardTransactionDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateOutwardTransactionDto updateOutwardTransactionDto)
        {
            var command = new UpdateOutwardTransactionCommand { OutwardTransactionDto = updateOutwardTransactionDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteOutwardTransactionCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}