using BankingBackend.Application.Features.TransactionFeatures.Models.Transaction;
using MediatR;

namespace BankingBackend.Application.Features.TransactionFeatures.Queries.GetTransaction
{
    public record GetTransactionQuery(Guid Id) : IRequest<TransactionViewModel>;
}
