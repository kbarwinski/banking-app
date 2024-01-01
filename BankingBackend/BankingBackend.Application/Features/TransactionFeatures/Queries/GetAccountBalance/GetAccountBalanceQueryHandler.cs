using BankingBackend.Application.Features.TransactionFeatures.Models.AccountBalance;
using BankingBackend.Application.Services;
using MediatR;

namespace BankingBackend.Application.Features.TransactionFeatures.Queries.GetAccountBalance
{
    internal class GetAccountBalanceQueryHandler : IRequestHandler<GetAccountBalanceQuery, AccountBalanceHistoryModel>
    {
        private readonly IAccountBalanceService _accountBalanceService;

        public GetAccountBalanceQueryHandler(IAccountBalanceService accountBalanceService)
        {
            _accountBalanceService = accountBalanceService;
        }

        public async Task<AccountBalanceHistoryModel> Handle(GetAccountBalanceQuery request, CancellationToken cancellationToken)
        {
            return await _accountBalanceService.GetCurrentBalance(cancellationToken);
        }
    }
}
