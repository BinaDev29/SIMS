using Application.CQRS.InwardTransactions.Commands.CreateInwardTransaction;
using Application.CQRS.InwardTransactions.Commands.DeleteInwardTransaction;
using Application.CQRS.InwardTransactions.Commands.UpdateInwardTransaction;
using Application.CQRS.InwardTransactions.Queries.GetInwardTransactionDetail;
using Application.CQRS.InwardTransactions.Queries.GetInwardTransactionsList;
using Application.DTOs.InwardTransactions;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InwardTransactionController : BaseApiController
    {
        private readonly IMediator _mediator;

        public InwardTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<InwardTransactionDto>>> Get()
        {
            var query = new GetInwardTransactionsListQuery();
            var inwardTransactions = await _mediator.Send(query);
            return Ok(inwardTransactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InwardTransactionDto>> Get(int id)
        {
            var query = new GetInwardTransactionDetailQuery { Id = id };
            var inwardTransaction = await _mediator.Send(query);
            return Ok(inwardTransaction);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateInwardTransactionDto createInwardTransactionDto)
        {
            var command = new CreateInwardTransactionCommand { InwardTransactionDto = createInwardTransactionDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateInwardTransactionDto updateInwardTransactionDto)
        {
            var command = new UpdateInwardTransactionCommand { InwardTransactionDto = updateInwardTransactionDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteInwardTransactionCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}