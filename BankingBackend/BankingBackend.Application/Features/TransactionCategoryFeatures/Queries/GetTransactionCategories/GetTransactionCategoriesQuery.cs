using BankingBackend.Application.Features.TransactionCategoryFeatures.Models;
using MediatR;

namespace BankingBackend.Application.Features.TransactionCategoryFeatures.Queries.GetTransactionCategories
{
    public record GetTransactionCategoriesQuery(bool? IncomeCategories) : IRequest<IEnumerable<TransactionCategoryModel>>;
}
