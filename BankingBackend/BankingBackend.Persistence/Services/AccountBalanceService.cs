using BankingBackend.Application.Features.TransactionFeatures.Models.AccountBalance;
using BankingBackend.Application.Repositories;
using BankingBackend.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BankingBackend.Persistence.Services
{
    public class AccountBalanceService : IAccountBalanceService
    {
        private AccountBalanceHistoryModel _currentBalance;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private bool _shouldRecalculate;
        private readonly SemaphoreSlim _balanceRecalculationLock = new SemaphoreSlim(1, 1);

        public AccountBalanceService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _currentBalance = new AccountBalanceHistoryModel();
            MarkForRecalculation();
        }

        public void MarkForRecalculation() => _shouldRecalculate = true;

        public async Task<AccountBalanceHistoryModel> GetCurrentBalance(CancellationToken cancellationToken)
        {
            if (_shouldRecalculate)
            {
                await _balanceRecalculationLock.WaitAsync(cancellationToken);

                try
                {
                    if (_shouldRecalculate)
                    {
                        using var scope = _serviceScopeFactory.CreateScope();
                        var transactionRepository = scope.ServiceProvider.GetRequiredService<ITransactionRepository>();

                        await RecalculateBalanceAsync(transactionRepository, cancellationToken);
                    }
                }
                finally
                {
                    _balanceRecalculationLock.Release();
                }
            }

            return _currentBalance;
        }

        public async Task RecalculateBalanceAsync(ITransactionRepository transactionRepository, CancellationToken cancellationToken)
        {
            var transactionsToCount = await transactionRepository.GetAll(cancellationToken);

            var groupedByDay = transactionsToCount
                .GroupBy(x => x.OccuredAt.Date)
                .OrderBy(x => x.Key);

            _currentBalance = new AccountBalanceHistoryModel
            {
                BalanceHistory = new List<AccountBalanceModel>()
            };

            decimal totalAmount = 0;
            foreach (var transactionsGroup in groupedByDay)
            {
                totalAmount += transactionsGroup.Sum(x => x.Amount);

                _currentBalance.BalanceHistory.Add(new AccountBalanceModel
                {
                    Date = transactionsGroup.Key,
                    Amount = totalAmount
                });
            }
        }
    }
}
