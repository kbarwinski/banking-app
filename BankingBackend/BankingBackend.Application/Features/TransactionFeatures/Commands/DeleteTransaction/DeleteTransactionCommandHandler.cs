using BankingBackend.Application.Common.Exceptions;
using BankingBackend.Application.Repositories;
using BankingBackend.Application.Services;
using MediatR;

namespace BankingBackend.Application.Features.TransactionFeatures.Commands.DeleteTransaction
{
    internal class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountBalanceService _accountBalanceService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository,
            IAccountBalanceService accountBalanceService,
            IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _accountBalanceService = accountBalanceService;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _transactionRepository.Get(x => x.Id == request.Id, cancellationToken, asNoTracking: false);
            if (entity == null)
                throw new NotFoundException("Transaction not found.");

            var currentBalance = (await _accountBalanceService.GetCurrentBalance(cancellationToken)).BalanceHistory.Last().Amount;

            if (currentBalance - entity.Amount < 0)
                throw new BadRequestException("Insuccifient funds");

            _transactionRepository.Delete(entity);

            await _unitOfWork.Save(cancellationToken);
        }
    }
}
