using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Godowns.Commands.CreateGodown
{
    public class CreateGodownCommandHandler : IRequestHandler<CreateGodownCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<Godown> _godownRepository;
        private readonly IMapper _mapper;

        public CreateGodownCommandHandler(IGenericRepository<Godown> godownRepository, IMapper mapper)
        {
            _godownRepository = godownRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateGodownCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var godown = _mapper.Map<Godown>(request.GodownDto);

            await _godownRepository.AddAsync(godown);

            response.Success = true;
            response.Message = "Godown Created Successfully";

            return response;
        }
    }
}