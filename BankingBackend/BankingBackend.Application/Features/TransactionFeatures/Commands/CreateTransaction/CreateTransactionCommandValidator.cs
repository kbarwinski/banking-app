using BankingBackend.Application.Features.TransactionFeatures.Models.Transaction;
using BankingBackend.Application.Repositories;
using BankingBackend.Application.Services;
using FluentValidation;

namespace BankingBackend.Application.Features.TransactionFeatures.Commands.CreateTransaction
{
    public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
    {
        public CreateTransactionCommandValidator(ITransactionCategoryRepository transactionCategoryRepository, IAccountBalanceService accountBalanceService)
        {
            RuleFor(x => x.Model)
                .SetValidator(new TransactionBaseModelValidator(transactionCategoryRepository, accountBalanceService));
        }
    }
}
