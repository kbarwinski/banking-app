using BankingBackend.Application.Features.TransactionFeatures.Models.AccountBalance;
using MediatR;

namespace BankingBackend.Application.Features.TransactionFeatures.Queries.GetAccountBalance
{
    public class GetAccountBalanceQuery : IRequest<AccountBalanceHistoryModel>
    {
        public DateTimeOffset? StartAt { get; set; }
        public DateTimeOffset? EndAt { get; set; }
    }
}
