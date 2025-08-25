using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.InwardTransactions;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.InwardTransactions.Queries.GetInwardTransactionDetail
{
    public class GetInwardTransactionDetailQueryHandler : IRequestHandler<GetInwardTransactionDetailQuery, InwardTransactionDto>
    {
        private readonly IInwardTransactionRepository _inwardTransactionRepository;
        private readonly IMapper _mapper;

        public GetInwardTransactionDetailQueryHandler(IInwardTransactionRepository inwardTransactionRepository, IMapper mapper)
        {
            _inwardTransactionRepository = inwardTransactionRepository;
            _mapper = mapper;
        }

        public async Task<InwardTransactionDto> Handle(GetInwardTransactionDetailQuery request, CancellationToken cancellationToken)
        {
            var inwardTransaction = await _inwardTransactionRepository.GetByIdAsync(request.Id, cancellationToken);
            if (inwardTransaction == null)
            {
                throw new NotFoundException(nameof(InwardTransaction), request.Id);
            }
            return _mapper.Map<InwardTransactionDto>(inwardTransaction);
        }
    }
}