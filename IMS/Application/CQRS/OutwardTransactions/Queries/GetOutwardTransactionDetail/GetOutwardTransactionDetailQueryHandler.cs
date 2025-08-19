using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.OutwardTransactions;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.OutwardTransactions.Queries.GetOutwardTransactionDetail
{
    public class GetOutwardTransactionDetailQueryHandler : IRequestHandler<GetOutwardTransactionDetailQuery, OutwardTransactionDto>
    {
        private readonly IGenericRepository<OutwardTransaction> _outwardTransactionRepository;
        private readonly IMapper _mapper;

        public GetOutwardTransactionDetailQueryHandler(IGenericRepository<OutwardTransaction> outwardTransactionRepository, IMapper mapper)
        {
            _outwardTransactionRepository = outwardTransactionRepository;
            _mapper = mapper;
        }

        public async Task<OutwardTransactionDto> Handle(GetOutwardTransactionDetailQuery request, CancellationToken cancellationToken)
        {
            var outwardTransaction = await _outwardTransactionRepository.GetByIdAsync(request.Id);
            if (outwardTransaction == null)
            {
                throw new NotFoundException(nameof(OutwardTransaction), request.Id);
            }
            return _mapper.Map<OutwardTransactionDto>(outwardTransaction);
        }
    }
}