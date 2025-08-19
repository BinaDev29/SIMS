using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.InwardTransactions.Commands.CreateInwardTransaction
{
    public class CreateInwardTransactionCommandHandler : IRequestHandler<CreateInwardTransactionCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<InwardTransaction> _inwardTransactionRepository;
        private readonly IMapper _mapper;

        public CreateInwardTransactionCommandHandler(IGenericRepository<InwardTransaction> inwardTransactionRepository, IMapper mapper)
        {
            _inwardTransactionRepository = inwardTransactionRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateInwardTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var inwardTransaction = _mapper.Map<InwardTransaction>(request.InwardTransactionDto);

            await _inwardTransactionRepository.AddAsync(inwardTransaction);

            response.Success = true;
            response.Message = "Inward Transaction Created Successfully";

            return response;
        }
    }
}