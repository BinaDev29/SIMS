// Application/CQRS/Report/Queries/GetGodownReportQueryHandler.cs
using AutoMapper;
using MediatR;
using Application.Contracts;
using Application.DTOs.Reports;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
            var godowns = await _godownRepository.GetAllAsync();

            var godownReports = new List<GodownReportDto>();
            foreach (var godown in godowns)
            {
                godownReports.Add(new GodownReportDto
                {
                    Id = godown.Id,
                    GodownName = godown.GodownName,
                    NumberOfItems = godown.Items.Count // Use .Count property
                });
            }
            return godownReports;
        }
    }
}