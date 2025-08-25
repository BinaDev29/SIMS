using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.OutwardTransactions;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Responses;

namespace Application.CQRS.OutwardTransactions.Queries.GetOutwardTransactionDetail
{
    public class GetOutwardTransactionDetailQueryHandler : IRequestHandler<GetOutwardTransactionDetailQuery, OutwardTransactionDto>
    {
        private readonly IOutwardTransactionRepository _outwardTransactionRepository; // Changed to specific repository
        private readonly IMapper _mapper;

        public GetOutwardTransactionDetailQueryHandler(IOutwardTransactionRepository outwardTransactionRepository, IMapper mapper) // Changed to specific repository
        {
            _outwardTransactionRepository = outwardTransactionRepository;
            _mapper = mapper;
        }

        public async Task<OutwardTransactionDto> Handle(GetOutwardTransactionDetailQuery request, CancellationToken cancellationToken)
        {
            var outwardTransaction = await _outwardTransactionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (outwardTransaction == null)
            {
                throw new NotFoundException(nameof(OutwardTransaction), request.Id);
            }
            return _mapper.Map<OutwardTransactionDto>(outwardTransaction);
        }
    }
}