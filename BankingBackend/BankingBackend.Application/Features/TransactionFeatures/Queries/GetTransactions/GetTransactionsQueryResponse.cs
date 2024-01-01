using BankingBackend.Application.Common.Queries;
using BankingBackend.Application.Features.TransactionFeatures.Models.Transaction;

namespace BankingBackend.Application.Features.TransactionFeatures.Queries.GetTransactions
{
    public sealed class GetTransactionsQueryResponse : BasePaginationResponse<TransactionViewModel>
    {
    }
}
