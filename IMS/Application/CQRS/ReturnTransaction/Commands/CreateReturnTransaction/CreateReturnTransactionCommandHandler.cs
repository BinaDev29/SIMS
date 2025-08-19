using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.ReturnTransactions.Commands.CreateReturnTransaction
{
    public class CreateReturnTransactionCommandHandler : IRequestHandler<CreateReturnTransactionCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<ReturnTransaction> _returnTransactionRepository;
        private readonly IMapper _mapper;

        public CreateReturnTransactionCommandHandler(IGenericRepository<ReturnTransaction> returnTransactionRepository, IMapper mapper)
        {
            _returnTransactionRepository = returnTransactionRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateReturnTransactionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var returnTransaction = _mapper.Map<ReturnTransaction>(request.ReturnTransactionDto);

            await _returnTransactionRepository.AddAsync(returnTransaction);

            response.Success = true;
            response.Message = "Return Transaction Created Successfully";

            return response;
        }
    }
}