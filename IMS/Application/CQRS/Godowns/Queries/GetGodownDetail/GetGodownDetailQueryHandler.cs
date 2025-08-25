using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.Godowns;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.Godowns.Queries.GetGodownDetail
{
    public class GetGodownDetailQueryHandler : IRequestHandler<GetGodownDetailQuery, GodownDto>
    {
        private readonly IGenericRepository<Godown> _godownRepository;
        private readonly IMapper _mapper;

        public GetGodownDetailQueryHandler(IGenericRepository<Godown> godownRepository, IMapper mapper)
        {
            _godownRepository = godownRepository;
            _mapper = mapper;
        }

        public async Task<GodownDto> Handle(GetGodownDetailQuery request, CancellationToken cancellationToken)
        {
            var godown = await _godownRepository.GetByIdAsync(request.Id, cancellationToken);
            if (godown == null)
            {
                throw new NotFoundException(nameof(Godown), request.Id);
            }
            return _mapper.Map<GodownDto>(godown);
        }
    }
}