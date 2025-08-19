using MediatR;
using Application.DTOs.InwardTransactions;
using System.Collections.Generic;

namespace Application.CQRS.InwardTransactions.Queries.GetInwardTransactionsList
{
    public class GetInwardTransactionsListQuery : IRequest<IReadOnlyList<InwardTransactionDto>>
    {

    }
}