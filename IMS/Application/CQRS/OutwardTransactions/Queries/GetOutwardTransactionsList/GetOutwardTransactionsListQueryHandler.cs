using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.OutwardTransactions;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Responses;

namespace Application.CQRS.OutwardTransactions.Queries.GetOutwardTransactionsList
{
    public class GetOutwardTransactionsListQueryHandler : IRequestHandler<GetOutwardTransactionsListQuery, IReadOnlyList<OutwardTransactionDto>>
    {
        private readonly IOutwardTransactionRepository _outwardTransactionRepository; // Changed to specific repository
        private readonly IMapper _mapper;

        public GetOutwardTransactionsListQueryHandler(IOutwardTransactionRepository outwardTransactionRepository, IMapper mapper) // Changed to specific repository
        {
            _outwardTransactionRepository = outwardTransactionRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<OutwardTransactionDto>> Handle(GetOutwardTransactionsListQuery request, CancellationToken cancellationToken)
        {
            var outwardTransactions = await _outwardTransactionRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IReadOnlyList<OutwardTransactionDto>>(outwardTransactions);
        }
    }
}