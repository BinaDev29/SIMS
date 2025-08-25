// Application/CQRS/Godowns/Commands/UpdateGodown/UpdateGodownCommandHandler.cs
using Application.Contracts;
using Application.Exceptions;
using Application.Responses;
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Godowns.Commands.UpdateGodown
{
    public class UpdateGodownCommandHandler : IRequestHandler<UpdateGodownCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<Godown> _godownRepository;
        private readonly IMapper _mapper;

        public UpdateGodownCommandHandler(IGenericRepository<Godown> godownRepository, IMapper mapper)
        {
            _godownRepository = godownRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateGodownCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var godownToUpdate = await _godownRepository.GetByIdAsync(request.GodownDto.Id, cancellationToken);

            if (godownToUpdate == null) // Simplified Null check
            {
                response.Success = false;
                response.Message = "Godown not found.";
                return response;
            }

            _mapper.Map(request.GodownDto, godownToUpdate);
            await _godownRepository.UpdateAsync(godownToUpdate, cancellationToken);

            response.Success = true;
            response.Message = "Godown Updated Successfully";
            return response;
        }
    }
}