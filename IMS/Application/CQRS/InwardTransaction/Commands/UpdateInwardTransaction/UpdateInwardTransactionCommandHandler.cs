using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.InwardTransactions.Commands.UpdateInwardTransaction
{
    public class UpdateInwardTransactionCommandHandler : IRequestHandler<UpdateInwardTransactionCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<InwardTransaction> _inwardTransactionRepository;
        private readonly IMapper _mapper;

        public UpdateInwardTransactionCommandHandler(IGenericRepository<InwardTransaction> inwardTransactionRepository, IMapper mapper)
        {
            _inwardTransactionRepository = inwardTransactionRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateInwardTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var inwardTransactionToUpdate = await _inwardTransactionRepository.GetByIdAsync(request.InwardTransactionDto.Id);

            if (inwardTransactionToUpdate == null)
            {
                response.Success = false;
                response.Message = "Inward Transaction not found.";
                return response;
            }

            _mapper.Map(request.InwardTransactionDto, inwardTransactionToUpdate);
            await _inwardTransactionRepository.UpdateAsync(inwardTransactionToUpdate);

            response.Success = true;
            response.Message = "Inward Transaction Updated Successfully";
            return response;
        }
    }
}