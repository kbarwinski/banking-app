using AutoMapper;
using BankingBackend.Application.Common.Exceptions;
using BankingBackend.Application.Features.TransactionFeatures.Models.Transaction;
using BankingBackend.Application.Repositories;
using MediatR;

namespace BankingBackend.Application.Features.TransactionFeatures.Queries.GetTransaction
{
    internal sealed class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, TransactionViewModel>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<TransactionViewModel> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            var entity = await _transactionRepository.Get(x => x.Id == request.Id, cancellationToken, asNoTracking: false, includeProperties: x => x.Category);
            if (entity == null)
                throw new NotFoundException("Transaction not found.");

            return _mapper.Map<TransactionViewModel>(entity);
        }
    }
}
