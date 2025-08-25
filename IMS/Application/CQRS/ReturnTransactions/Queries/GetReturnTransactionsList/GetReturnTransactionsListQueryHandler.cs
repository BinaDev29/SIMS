using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.ReturnTransactions;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.ReturnTransactions.Queries.GetReturnTransactionsList
{
    public class GetReturnTransactionsListQueryHandler : IRequestHandler<GetReturnTransactionsListQuery, IReadOnlyList<ReturnTransactionDto>>
    {
        private readonly IReturnTransactionRepository _returnTransactionRepository; // Changed to specific repository
        private readonly IMapper _mapper;

        public GetReturnTransactionsListQueryHandler(IReturnTransactionRepository returnTransactionRepository, IMapper mapper) // Changed to specific repository
        {
            _returnTransactionRepository = returnTransactionRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ReturnTransactionDto>> Handle(GetReturnTransactionsListQuery request, CancellationToken cancellationToken)
        {
            var returnTransactions = await _returnTransactionRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IReadOnlyList<ReturnTransactionDto>>(returnTransactions);
        }
    }
}