using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.OutwardTransactions.Commands.CreateOutwardTransaction
{
    public class CreateOutwardTransactionCommandHandler : IRequestHandler<CreateOutwardTransactionCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<OutwardTransaction> _outwardTransactionRepository;
        private readonly IMapper _mapper;

        public CreateOutwardTransactionCommandHandler(IGenericRepository<OutwardTransaction> outwardTransactionRepository, IMapper mapper)
        {
            _outwardTransactionRepository = outwardTransactionRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateOutwardTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var outwardTransaction = _mapper.Map<OutwardTransaction>(request.OutwardTransactionDto);

            await _outwardTransactionRepository.AddAsync(outwardTransaction);

            response.Success = true;
            response.Message = "Outward Transaction Created Successfully";

            return response;
        }
    }
}