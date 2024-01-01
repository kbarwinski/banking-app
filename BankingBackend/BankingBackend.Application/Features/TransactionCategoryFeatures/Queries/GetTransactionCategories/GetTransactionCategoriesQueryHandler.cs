using AutoMapper;
using BankingBackend.Application.Features.TransactionCategoryFeatures.Models;
using BankingBackend.Application.Repositories;
using MediatR;

namespace BankingBackend.Application.Features.TransactionCategoryFeatures.Queries.GetTransactionCategories
{
    internal class GetTransactionCategoriesQueryHandler : IRequestHandler<GetTransactionCategoriesQuery, IEnumerable<TransactionCategoryModel>>
    {
        private readonly ITransactionCategoryRepository _transactionCategoryRepository;
        private readonly IMapper _mapper;

        public GetTransactionCategoriesQueryHandler(ITransactionCategoryRepository transactionCategoryRepository, IMapper mapper)
        {
            _transactionCategoryRepository = transactionCategoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionCategoryModel>> Handle(GetTransactionCategoriesQuery request, CancellationToken cancellationToken)
        {
            var res = await _transactionCategoryRepository.GetWhere(x => request.IncomeCategories != null ? x.IsIncomeCategory == request.IncomeCategories : true, cancellationToken);

            return _mapper.Map<List<TransactionCategoryModel>>(res);
        }
    }
}
