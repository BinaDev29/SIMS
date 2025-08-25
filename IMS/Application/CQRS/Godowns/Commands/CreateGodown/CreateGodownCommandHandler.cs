using Application.Contracts;
using Application.Responses;
using AutoMapper;
using Domain.Models;
using MediatR;
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

            // Passing the cancellation token
            await _godownRepository.AddAsync(godown, cancellationToken);

            response.Success = true;
            response.Message = "Godown Created Successfully";
            response.Id = godown.Id; // Ensure the ID is returned

            return response;
        }
    }
}