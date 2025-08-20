using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Reports;
using Application.CQRS.Report.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("stock")]
        public async Task<ActionResult<IReadOnlyList<StockReportDto>>> GetStockReport()
        {
            var query = new GetStockReportQuery();
            var report = await _mediator.Send(query);
            return Ok(report);
        }

        [HttpGet("godown")]
        public async Task<ActionResult<IReadOnlyList<GodownReportDto>>> GetGodownReport()
        {
            var query = new GetGodownReportQuery();
            var report = await _mediator.Send(query);
            return Ok(report);
        }
    }
}