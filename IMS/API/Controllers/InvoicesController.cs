// API/Controllers/InvoicesController.cs
using Application.CQRS.Invoices.Commands;
using Application.DTOs.Invoices;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    // ከ ControllerBase ይልቅ BaseApiController እንዲወርስ አድርግ
    // [ApiController] እና [Route] attributeን አጥፋ ምክንያቱም BaseApiController ቀድሞውንም አለው
    [Authorize] // ይህ attribute ለዚህ controller ብቻ ስለሆነ ሊኖር ይገባል
    public class InvoicesController : BaseApiController
    {
        // IMediatorን ከ BaseApiController ስለምትወርስ constructorም ሆነ የ _mediator ንብረቱን እንደገና መግለጽ አያስፈልግም

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateInvoiceDto createInvoiceDto)
        {
            var command = new CreateInvoiceCommand { InvoiceDto = createInvoiceDto };
            var response = await Mediator.Send(command);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}