using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.ReturnTransactions;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.ReturnTransactions.Queries.GetReturnTransactionDetail
{
    public class GetReturnTransactionDetailQueryHandler : IRequestHandler<GetReturnTransactionDetailQuery, ReturnTransactionDto>
    {
        private readonly IGenericRepository<ReturnTransaction> _returnTransactionRepository;
        private readonly IMapper _mapper;

        public GetReturnTransactionDetailQueryHandler(IGenericRepository<ReturnTransaction> returnTransactionRepository, IMapper mapper)
        {
            _returnTransactionRepository = returnTransactionRepository;
            _mapper = mapper;
        }

        public async Task<ReturnTransactionDto> Handle(GetReturnTransactionDetailQuery request, CancellationToken cancellationToken)
        {
            var returnTransaction = await _returnTransactionRepository.GetByIdAsync(request.Id);
            if (returnTransaction == null)
            {
                throw new NotFoundException(nameof(ReturnTransaction), request.Id);
            }
            return _mapper.Map<ReturnTransactionDto>(returnTransaction);
        }
    }
}