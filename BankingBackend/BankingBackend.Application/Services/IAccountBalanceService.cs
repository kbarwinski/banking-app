using BankingBackend.Application.Features.TransactionFeatures.Models.AccountBalance;
using BankingBackend.Application.Repositories;

namespace BankingBackend.Application.Services
{
    public interface IAccountBalanceService
    {
        public Task<AccountBalanceHistoryModel> GetCurrentBalance(CancellationToken cancellationToken);
        public void MarkForRecalculation();
        public Task RecalculateBalanceAsync(ITransactionRepository transactionRepository, CancellationToken cancellationToken);
    }
}
