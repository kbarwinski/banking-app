using AutoMapper;
using BankingBackend.Application.Features.TransactionFeatures.Models.Transaction;
using BankingBackend.Application.Repositories;
using BankingBackend.Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace BankingBackend.Application.Features.TransactionFeatures.Queries.GetTransactions
{
    internal sealed class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, GetTransactionsQueryResponse>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionsQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<GetTransactionsQueryResponse> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            var filterRules = new Dictionary<Expression<Func<Transaction, bool>>, bool>
            {
                { x => request.CategoryIds.Contains(x.Category.Id), request.CategoryIds != null && request.CategoryIds.Any() }
            };

            var orderRules = new Dictionary<string, Expression<Func<Transaction, object>>>
            {
                [""] = x => x.OccuredAt
            };

            var (res, pagination) = await _transactionRepository
                .GetFilteredAndOrderedPage(request, filterRules, orderRules, cancellationToken, includeProperties: x => x.Category);

            return new GetTransactionsQueryResponse
            {
                Result = _mapper.Map<List<TransactionViewModel>>(res),
                Pagination = pagination
            };
        }
    }
}
