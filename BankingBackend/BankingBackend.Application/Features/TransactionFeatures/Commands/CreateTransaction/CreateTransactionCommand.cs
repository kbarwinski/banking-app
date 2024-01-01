using BankingBackend.Application.Common.Behaviors;
using BankingBackend.Application.Features.TransactionFeatures.Models.Transaction;
using MediatR;

namespace BankingBackend.Application.Features.TransactionFeatures.Commands.CreateTransaction
{
    public record CreateTransactionCommand(TransactionBaseModel Model) : IRequest<TransactionViewModel>, ITriggerAccountBalanceRecalculation;
}
