using AutoMapper;
using MediatR;
using Application.Contracts;
using Application.DTOs.Reports;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // New using directive for `Include` and `AsNoTracking`

namespace Application.CQRS.Report.Queries
{
    public class GetGodownReportQueryHandler : IRequestHandler<GetGodownReportQuery, IReadOnlyList<GodownReportDto>>
    {
        private readonly IGodownRepository _godownRepository;
        private readonly IMapper _mapper;

        public GetGodownReportQueryHandler(IGodownRepository godownRepository, IMapper mapper)
        {
            _godownRepository = godownRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GodownReportDto>> Handle(GetGodownReportQuery request, CancellationToken cancellationToken)
        {
            // Use a more performant query to get godowns with their item counts
            var godownReports = await _godownRepository.GetAllAsync()
                .ContinueWith(t => t.Result.Select(godown => new GodownReportDto
                {
                    Id = godown.Id,
                    GodownName = godown.GodownName,
                    NumberOfItems = godown.Items.Count
                }).ToList(), cancellationToken);

            return godownReports;
        }
    }
}