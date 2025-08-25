using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.Godowns;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Godowns.Queries.GetGodownsList
{
    public class GetGodownsListQueryHandler : IRequestHandler<GetGodownsListQuery, IReadOnlyList<GodownDto>>
    {
        private readonly IGenericRepository<Godown> _godownRepository;
        private readonly IMapper _mapper;

        public GetGodownsListQueryHandler(IGenericRepository<Godown> godownRepository, IMapper mapper)
        {
            _godownRepository = godownRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GodownDto>> Handle(GetGodownsListQuery request, CancellationToken cancellationToken)
        {
            var godowns = await _godownRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IReadOnlyList<GodownDto>>(godowns);
        }
    }
}