using AutoMapper;
using MediatR;
using Application.Contracts;
using Application.DTOs.Reports;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Report.Queries
{
    public class GetStockReportQueryHandler : IRequestHandler<GetStockReportQuery, IReadOnlyList<StockReportDto>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetStockReportQueryHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<StockReportDto>> Handle(GetStockReportQuery request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IReadOnlyList<StockReportDto>>(items);
        }
    }
}