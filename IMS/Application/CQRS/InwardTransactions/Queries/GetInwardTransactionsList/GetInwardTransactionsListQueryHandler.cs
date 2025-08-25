using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.InwardTransactions;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.InwardTransactions.Queries.GetInwardTransactionsList
{
    public class GetInwardTransactionsListQueryHandler : IRequestHandler<GetInwardTransactionsListQuery, IReadOnlyList<InwardTransactionDto>>
    {
        private readonly IInwardTransactionRepository _inwardTransactionRepository;
        private readonly IMapper _mapper;

        public GetInwardTransactionsListQueryHandler(IInwardTransactionRepository inwardTransactionRepository, IMapper mapper)
        {
            _inwardTransactionRepository = inwardTransactionRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<InwardTransactionDto>> Handle(GetInwardTransactionsListQuery request, CancellationToken cancellationToken)
        {
            var inwardTransactions = await _inwardTransactionRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IReadOnlyList<InwardTransactionDto>>(inwardTransactions);
        }
    }
}