using BankingBackend.Application.Repositories;
using BankingBackend.Application.Services;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace BankingBackend.Application.Features.TransactionFeatures.Models.Transaction
{
    internal class TransactionBaseModelValidator : AbstractValidator<TransactionBaseModel>
    {
        private readonly ITransactionCategoryRepository _transactionCategoryRepository;
        private readonly IAccountBalanceService _accountBalanceService;

        private string _invalidCategoryMessage;

        public TransactionBaseModelValidator(ITransactionCategoryRepository transactionCategoryRepository, IAccountBalanceService accountBalanceService)
        {
            _accountBalanceService = accountBalanceService;
            _transactionCategoryRepository = transactionCategoryRepository;

            _invalidCategoryMessage = "";

            RuleFor(transaction => transaction.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");

            RuleFor(transaction => transaction.OccuredAt)
                .NotEmpty().WithMessage("Date of transaction is required.");

            RuleFor(transaction => transaction.Category)
                .NotNull().WithMessage("Transaction category is required.");

            RuleFor(transaction => transaction.Category.Id)
                .NotEmpty().WithMessage("Transaction category ID is required.");

            RuleFor(transaction => transaction)
                .Must(HasNonZeroAmount)
                    .WithMessage(x => "Invalid transaction amount.")
                .Must(HadOccuredInThePast)
                    .WithMessage(x => "Transaction cannot happen in the future")
                .MustAsync(HasValidCategory)
                    .WithMessage(x => $"Invalid category: {_invalidCategoryMessage}")
                .MustAsync(HasNonNegativeBalance)
                    .WithMessage(x => "Insuccifient funds.");
        }

        private async Task<bool> HasNonNegativeBalance(TransactionBaseModel transaction, CancellationToken cancellationToken)
        {
            var balanceBefore = (await _accountBalanceService.GetCurrentBalance(cancellationToken)).BalanceHistory
                .LastOrDefault(x => x.Date <= transaction.OccuredAt)?.Amount ?? 0;

            return balanceBefore + transaction.Amount >= 0;
        }


        private bool HasNonZeroAmount(TransactionBaseModel transaction)
            => transaction.Amount != 0;

        private bool HadOccuredInThePast(TransactionBaseModel transaction)
            => transaction.OccuredAt <= DateTimeOffset.UtcNow;
        private async Task<bool> HasValidCategory(TransactionBaseModel transaction, CancellationToken cancellationToken)
        {
            if (transaction.Category == null)
            {
                _invalidCategoryMessage = "category not provided.";
                return false;
            }

            var category = await _transactionCategoryRepository.Get(x => x.Id == transaction.Category.Id, cancellationToken, asNoTracking: true);

            if (category == null)
            {
                _invalidCategoryMessage = "category does not exist.";
                return false;
            }

            if ((category.IsIncomeCategory && transaction.Amount < 0) || (!category.IsIncomeCategory && transaction.Amount > 0))
            {
                _invalidCategoryMessage = "category invalid for the provided amount.";
                return false;
            }

            return true;
        }
    }
}
