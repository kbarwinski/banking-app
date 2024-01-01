using BankingBackend.Application.Services;
using MediatR;

namespace BankingBackend.Application.Common.Behaviors
{
    public interface ITriggerAccountBalanceRecalculation
    {
    }

    public class AccountBalanceRecalculationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IAccountBalanceService _accountBalanceService;

        public AccountBalanceRecalculationBehavior(IAccountBalanceService accountBalanceService)
        {
            _accountBalanceService = accountBalanceService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();

            if (request is ITriggerAccountBalanceRecalculation)
            {
                _accountBalanceService.MarkForRecalculation();
            }

            return response;
        }
    }
}
