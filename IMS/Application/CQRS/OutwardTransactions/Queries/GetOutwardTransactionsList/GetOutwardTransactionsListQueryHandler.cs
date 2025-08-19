using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.OutwardTransactions;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.OutwardTransactions.Queries.GetOutwardTransactionsList
{
    public class GetOutwardTransactionsListQueryHandler : IRequestHandler<GetOutwardTransactionsListQuery, IReadOnlyList<OutwardTransactionDto>>
    {
        private readonly IGenericRepository<OutwardTransaction> _outwardTransactionRepository;
        private readonly IMapper _mapper;

        public GetOutwardTransactionsListQueryHandler(IGenericRepository<OutwardTransaction> outwardTransactionRepository, IMapper mapper)
        {
            _outwardTransactionRepository = outwardTransactionRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<OutwardTransactionDto>> Handle(GetOutwardTransactionsListQuery request, CancellationToken cancellationToken)
        {
            var outwardTransactions = await _outwardTransactionRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<OutwardTransactionDto>>(outwardTransactions);
        }
    }
}