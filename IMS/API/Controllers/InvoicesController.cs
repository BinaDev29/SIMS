using Application.CQRS.Invoices.Commands;
using Application.DTOs.Invoices;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Can be restricted to a specific role if needed, e.g., [Authorize(Roles = "Admin")]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateInvoiceDto createInvoiceDto)
        {
            var command = new CreateInvoiceCommand { InvoiceDto = createInvoiceDto };
            var response = await _mediator.Send(command);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}