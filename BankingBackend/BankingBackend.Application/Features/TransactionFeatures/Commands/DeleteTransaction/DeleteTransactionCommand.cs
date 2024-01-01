using BankingBackend.Application.Common.Behaviors;
using MediatR;

namespace BankingBackend.Application.Features.TransactionFeatures.Commands.DeleteTransaction
{
    public record DeleteTransactionCommand(Guid Id) : IRequest, ITriggerAccountBalanceRecalculation;
}
