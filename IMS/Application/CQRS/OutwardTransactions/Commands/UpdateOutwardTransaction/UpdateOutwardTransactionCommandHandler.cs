using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.OutwardTransactions.Commands.UpdateOutwardTransaction
{
    public class UpdateOutwardTransactionCommandHandler : IRequestHandler<UpdateOutwardTransactionCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<OutwardTransaction> _outwardTransactionRepository;
        private readonly IMapper _mapper;

        public UpdateOutwardTransactionCommandHandler(IGenericRepository<OutwardTransaction> outwardTransactionRepository, IMapper mapper)
        {
            _outwardTransactionRepository = outwardTransactionRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateOutwardTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var outwardTransactionToUpdate = await _outwardTransactionRepository.GetByIdAsync(request.OutwardTransactionDto.Id);

            if (outwardTransactionToUpdate == null)
            {
                response.Success = false;
                response.Message = "Outward Transaction not found.";
                return response;
            }

            _mapper.Map(request.OutwardTransactionDto, outwardTransactionToUpdate);
            await _outwardTransactionRepository.UpdateAsync(outwardTransactionToUpdate);

            response.Success = true;
            response.Message = "Outward Transaction Updated Successfully";
            return response;
        }
    }
}