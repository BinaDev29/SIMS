using MediatR;
using System.Collections.Generic;
using Application.DTOs.Reports;

namespace Application.CQRS.Report.Queries
{
    public class GetStockReportQuery : IRequest<IReadOnlyList<StockReportDto>>
    {
    }
}